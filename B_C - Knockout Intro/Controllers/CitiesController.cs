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
            return ConnectionHelper.WithNewConnection(con =>
            {
                var cities = con.Query<City>("SELECT * FROM City");
                return cities;
            });
        }

        // GET api/<controller>/5
        public City Get(int id)
        {
            return ConnectionHelper.WithNewConnection(con =>
            {
                var city = con.Query<City>("SELECT * FROM City WHERE ID = @id", new { id }).FirstOrDefault();
                return city;
            });
        }

        // POST api/<controller>
        public void Post(City value)
        {
            ConnectionHelper.WithNewConnection((con) =>
            {
                con.Execute("INSERT INTO City (CountryCode, District, Name, Population) VALUES (@CountryCode, @District, @Name, @Population)",
                    new
                    {
                        value.CountryCode,
                        District = "",
                        value.Name,
                        value.Population,
                    });
            });
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
            if (id <= 4079) throw new Exception("Cannot edit cities that came with the database");
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            if (id <= 4079) throw new Exception("Cannot delete cities that came with the database");
            ConnectionHelper.WithNewConnection((con) =>
            {
                con.Execute("DELETE FROM City WHERE Id = @id",
                    new
                    {
                        id
                    });
            });
        }
    }
}