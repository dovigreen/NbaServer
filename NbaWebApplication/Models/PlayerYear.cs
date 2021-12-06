using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NbaWebApplication.Models
{
    public class PlayerYear
    {
        public Season Season { get; set; }
        public Player Player { get; set; }      
    }
}