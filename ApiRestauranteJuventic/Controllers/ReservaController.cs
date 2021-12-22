using ApiRestauranteJuventic.Models;
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
    public class ReservaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public ReservaController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        // GET: api/
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select id,id_cliente,id_servicio,fecha from reserva
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


        //////////////////////////////////////////



        //ELIMINACION
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from reserva 
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

        //ACTUALIZACIÓN


        [HttpPut]
        public JsonResult Put(Reserva reserva)
        {
            string query = @"
                        update reserva set 
                        id_cliente=@id_cliente,
                        id_servicio=@id_servicio,
                        descripcion=@descripcion,
                        fecha=@fecha
                        where id=@id;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id", reserva.id);
                    myCommand.Parameters.AddWithValue("@id_cliente", reserva.id_cliente);
                    myCommand.Parameters.AddWithValue("@id_servicio", reserva.id_servicio);
                    myCommand.Parameters.AddWithValue("@descripcion", reserva.descripcion);
                    myCommand.Parameters.AddWithValue("@fecha", reserva.fecha);


                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }
        //CREACIÓN

        [HttpPost]
        public JsonResult Post(Models.Reserva reserva)
        {
            string query = @"
                        insert into reserva 
                        (id_cliente,id_servicio,descripcion,fecha) 
                        values
                        (@id_cliente,@id_servicio,@descripcion,@fecha);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("basejuventic");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@id_cliente", reserva.id_cliente);
                    myCommand.Parameters.AddWithValue("@id_servicio", reserva.id_servicio);
                    myCommand.Parameters.AddWithValue("@descripcion", reserva.descripcion);
                    myCommand.Parameters.AddWithValue("@fecha", reserva.fecha);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


    }
}
