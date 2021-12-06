using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NbaWebApplication.Models
{
    public class PlayerYearList
    {
        private static List<PlayerYear> playerYears;

        private static readonly Lazy<PlayerYearList> LazyInstance = new Lazy<PlayerYearList>(() => new PlayerYearList());

        private PlayerYearList()
        {
            playerYears=new List<PlayerYear>();
        }

        public static PlayerYearList Instance
        {
            get { return LazyInstance.Value; }
        }

        public List<PlayerYear> PlayerYears
        {
            get { return playerYears; }

        }

    }
}