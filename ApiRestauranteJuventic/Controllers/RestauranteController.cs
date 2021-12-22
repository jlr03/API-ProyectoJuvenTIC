using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public RestauranteController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET: api/<RestauranteController>
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,nombre,descripcion from restaurante
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }
        // GET api/<RestauranteController>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                        select nombre,descripcion from restaurante where id = @id;
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        // POST api/restaurante
        [HttpPost]
        public JsonResult Post(Models.Restaurante res)
        {
            string query = @"
                        insert into restaurante 
                        (nombre,descripcion) 
                        values
                         (@RestauranteNombre,@RestauranteDescripcion) ;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@RestauranteNombre", res.nombre);
                    myCommand.Parameters.AddWithValue("@RestauranteDescripcion", res.descripcion);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // PUT api/<RestauranteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestauranteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}
