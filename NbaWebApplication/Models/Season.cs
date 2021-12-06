using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NbaWebApplication.Models
{
    public class Season
    {
        public int Year { get; set; }
        public decimal FieldGoalPercentage { get; set; }
        public decimal PointsPerGame { get; set; }
        public decimal ReboundsForGame { get; set; }
        public decimal AssistsPerGame { get; set; }
        public decimal BlocksPerGame { get; set; }

        public decimal Rank
        {
            get { return FieldGoalPercentage + PointsPerGame + ReboundsForGame + AssistsPerGame + BlocksPerGame; }

        }
    }
}