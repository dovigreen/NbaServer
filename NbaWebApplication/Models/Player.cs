using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Proxies;
using System.Web;
using Newtonsoft.Json;

namespace NbaWebApplication.Models
{ 
    public class Player
    {        
        public int Id { get; set; }        
        public string FirstName { get; set; }        
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public decimal Height { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }        
        public Team Team { get; set; }
    }
}