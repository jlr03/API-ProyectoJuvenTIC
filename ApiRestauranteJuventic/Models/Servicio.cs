using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Servicio
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string img { get; set; }
        public string id_restaurante { get; set; }
    }
}
