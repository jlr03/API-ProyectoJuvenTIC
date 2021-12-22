using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Empleado
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string cargo { get; set; }
        public string img { get; set; }
        public int id_restaurante { get; set; }
    }
}
