using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Treehouse.FitnessFrog.Shared.Models;

namespace Treehouse.FitnessFrog.Spa.Controllers
{
    public class EntriesController : ApiController
    {
        public IEnumerable<Entry> Get()
        {
            var activityBiking = new Activity() { Name = "Biking" };

            return new List<Entry>()
            {
                new Entry(2017, 1, 2, activityBiking, 10.0m),
                new Entry(2017, 1, 3, activityBiking, 12.2m)
            };
        }


        public Entry Get(int id )
        {
            return null;
        }

        public void Put()
        {

        }

        public void Post()
        {

        }

        public void Delete()
        {

        }
    }
}
