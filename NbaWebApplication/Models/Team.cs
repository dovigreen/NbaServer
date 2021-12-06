using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NbaWebApplication.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Conf { get; set; }        
        public string Color { get; set; }
    }
}