using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace NbaWebApplication.Models.Json
{
    public class Data
    {        
        public League league { get; set; }
    }

    public class League
    {        
        public List<Player> standard { get; set; }
    }

    public class Player
    {     
        public int personId { get; set; }        
        public string firstName { get; set; }        
        public string lastName { get; set; }
        public string teamId { get; set; }
        public string dateOfBirthUTC { get; set; }
        public string heightMeters { get; set; }
        public TeamSite teamSitesOnly { get; set; }
        public string country { get; set; }
        public bool isActive { get; set; }
    }

    public class TeamSite
    {
        public string posFull { get; set; }
    }

    public class DataProfile
    {
        public LeagueProfile league { get; set; }
    }

    public class LeagueProfile
    {
        public Standard standard { get; set; }
    }

    public class Standard
    {
        public Stats stats { get; set; }
    }

    public class Stats
    {
        public RegularSeason regularSeason { get; set; }
    }

    public class RegularSeason
    {
        public List<Season> season { get; set; }
    }

    public class Season
    {
        public int seasonYear { get; set; }
        public Total total { get; set; }

    }

    public class Total
    {
        public decimal fgp { get; set; }
        public decimal ppg { get; set; }
        public decimal rpg { get; set; }
        public decimal apg { get; set; }
        public decimal bpg { get; set; }
    }


}