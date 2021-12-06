using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NbaWebApplication.Models.Json
{
    public class DataTeams
    {
        public LeagueTeam league { get; set; }
    }

    public class LeagueTeam
    {
        public List<Team> standard { get; set; }
    }

    public class Team
    {
        public int teamId { get; set; }
        public string nickname { get; set; }
        public string confName { get; set; }

    }

    public class DataTeamsConfig
    {
        public Teams teams { get; set; }
    }

    public class Teams
    {
        public List<Config> config { get; set; }
    }

    public class Config
    {
        public int teamId { get; set; }
        public string primaryColor { get; set; }
    }
}