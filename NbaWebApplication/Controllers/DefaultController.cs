using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NbaWebApplication.Models;

namespace NbaWebApplication.Controllers
{
    public class DefaultController : ApiController
    {
        /// <summary>
        ///     Get the top 10 players by year
        /// </summary>
        /// <param name="id">year</param>
        /// <returns>List of playerList</returns>
        [HttpGet]
        public IHttpActionResult GetTop10(int id)
        {
            PlayerUtils playerUtils = new PlayerUtils();
            var top10 = playerUtils.GetTop10(id);
            if (top10 == null)
                return NotFound();
            return Ok(top10);
        }      
    }
}
