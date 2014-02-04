using System;
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
    public class CitiesController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<City> Get()
        {
            return WithNewConnection(con =>
            {
                var cities = con.Query<City>("SELECT * FROM City");
                return cities;
            });
        }

        // GET api/<controller>/5
        public City Get(int id)
        {
            return WithNewConnection(con =>
            {
                var city = con.Query<City>("SELECT * FROM City WHERE ID = @id", new { id }).FirstOrDefault();
                return city;
            });
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }

        private static T WithNewConnection<T>(Func<DbConnection, T> Code)
        {
            string connStr = "server=localhost;user=jjnguy;database=world;port=3307;password=asdf1234;";
            DbConnection con = new MySqlConnection(connStr);
            con.ConnectionString = connStr;
            con.Open();

            var result = Code(con);

            con.Close();

            return result;
        }
    }
}