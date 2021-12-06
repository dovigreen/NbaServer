using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace NbaWebApplication.Models.Json
{
    public class JsonUtils
    {
        public List<Player> GetAllPlayers(int year)
        {
            try
            {
                var json = DownloadAllPlayers(year);
                if (json != string.Empty)
                {
                    var data= JsonConvert.DeserializeObject<Data>(json);
                    return data.league.standard;
                }
                return null;

            }
            catch (Exception e)
            {
                throw;
            }                        
        }

        public List<Season> GetPlayerProfile(int year,int personId)
        {
            try
            {
                var json = DownloadPlayer(year, personId);
                if (json != string.Empty)
                {
                    var data = JsonConvert.DeserializeObject<DataProfile>(json);
                    return data.league.standard.stats.regularSeason.season;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


        public List<Team> GetTeams(int year)
        {
            var json = DownloadTeams(year);            
            if (json != string.Empty)
            {
                var data= JsonConvert.DeserializeObject<DataTeams>(json);
                return data.league.standard;
            }

            return null;

        }

        public List<Config> GetTeamsConfig(int year)
        {
            var json = DownloadTeamsConfig(year);
            if (json != string.Empty)
            {
                var data = JsonConvert.DeserializeObject<DataTeamsConfig>(json);
                return data.teams.config;
            }

            return null;

        }




        private string DownloadAllPlayers(int year)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    return wc.DownloadString("https://data.nba.net/data/10s/prod/v1/" + year + "/players.json");
                }
            }
            catch (Exception e)
            {
                return String.Empty;
            }            
        }

        private string DownloadPlayer(int year,int personId)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    return wc.DownloadString("https://data.nba.net/data/10s/prod/v1/" + year + "/players/" + personId + "_profile.json");
                }
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        private string DownloadTeams(int year)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    return wc.DownloadString("https://data.nba.net/data/10s/prod/v1/"+year+"/teams.json");
                }
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }

        private string DownloadTeamsConfig(int year)
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    return wc.DownloadString("https://data.nba.net/data/1h/prod/"+year+"/teams_config.json");
                }
            }
            catch (Exception e)
            {
                return String.Empty;
            }
        }
    }
}