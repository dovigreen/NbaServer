using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using NbaWebApplication.Models.Json;
using Newtonsoft.Json;

namespace NbaWebApplication.Models
{
    public class PlayerUtils
    {
        
        public List<PlayerYear> GetTop10(int year)
        {
            var playerYears = GetPlayerYears(year);
            return playerYears.Where(p => p.Season.Year == year).OrderByDescending(p => p.Season.Rank).Take(10).ToList();
        }

        private List<PlayerYear> GetPlayerYears(int year)
        {
            PlayerYearList playerYearList=PlayerYearList.Instance;

            List<PlayerYear> playerYears = playerYearList.PlayerYears;

            List<Player> players = GetAllPlayers(year);
            foreach (var player in players/*.Take(20)*/)
            {
                if (!playerYears.Exists(p => p.Player.Id == player.Id && p.Season.Year == year))
                {
                    //יכול להיות שהשחקן לא קיים לשנה הזו אבל כן כבר קיים לעונות אחרות ולכן אם הוא קיים לעונה האחרת אז לא להוסיף אותה שוב
                    var seasons = GetPlayerProfile(year, player.Id);
                    foreach (var season in seasons)
                    {
                        if (!playerYears.Exists(p => p.Player.Id==player.Id && p.Season.Year == season.Year))
                        {
                            PlayerYear playerYear = new PlayerYear()
                            {
                                Player = player,
                                Season = season
                            };
                            playerYears.Add(playerYear);
                        }
                    }
                }

            }

            return playerYears;
        }

        private List<Player> GetAllPlayers(int year)
        {
            List<Team> allTeams = GetAllTeams(year);
            if (allTeams != null)
            {
                JsonUtils jsonUtils = new JsonUtils();
                var allPlayers = jsonUtils.GetAllPlayers(year);
                return allPlayers.Where(p => p.isActive).Select(p => new Player()
                {
                    Id = p.personId,
                    FirstName = p.firstName,
                    LastName = p.lastName,
                    BirthDate = p.dateOfBirthUTC != string.Empty
                        ? DateTime.Parse(p.dateOfBirthUTC).ToString("dd/MM/yyyy")
                        : string.Empty,
                    Country = p.country,
                    Height = p.heightMeters != string.Empty ? Convert.ToDecimal(p.heightMeters) : 0,
                    Position = p.teamSitesOnly?.posFull,
                    Team = allTeams.FirstOrDefault(t => t.Id == Convert.ToInt32(p.teamId))
                }).ToList();
            }

            return null;
        }

        private List<Team> GetAllTeams(int year)
        {
            JsonUtils jsonUtils = new JsonUtils();
            var teamsConfig = jsonUtils.GetTeamsConfig(year);
            var allTeams=jsonUtils.GetTeams(year);
            if (allTeams != null)
            {
                return allTeams.Select(t => new Team()
                {
                    Id = t.teamId,
                    Name = t.nickname,
                    Conf = t.confName,
                    Color = teamsConfig?.FirstOrDefault(c => c.teamId == t.teamId)?.primaryColor
                }).ToList();
            }

            return null;
        }

        

        private List<Season> GetPlayerProfile(int year, int id)
        {            
            JsonUtils jsonUtils=new JsonUtils();
            var playerProfile = jsonUtils.GetPlayerProfile(year, id);
            return playerProfile.Select(p => new Season()
            {
                Year = p.seasonYear,
                FieldGoalPercentage = p.total.fgp,
                PointsPerGame = p.total.ppg,
                ReboundsForGame = p.total.rpg,
                AssistsPerGame = p.total.apg,
                BlocksPerGame = p.total.bpg
                
            }).ToList();
        }       
    }
}