using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using B_C___Knockout_Intro.Models;
using Dapper;
using MySql.Data.MySqlClient;

namespace B_C___Knockout_Intro.Controllers
{
    public class CountriesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Country> Get()
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                var countries = con.Query<Country>("SELECT * FROM Country");
                return countries;
            });
        }

        // GET api/<controller>/5
        public City Get(string code)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                var country = con.Query<City>("SELECT * FROM Country WHERE Code = @code", new { code }).FirstOrDefault();
                return country;
            });
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            ConnectionHelper.WithNewConnection((con) =>
            {

            });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
