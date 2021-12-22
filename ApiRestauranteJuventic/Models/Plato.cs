using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Plato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
        public string descripcion { get; set; }
        public string descripcion_larga { get; set; }
        public string img { get; set; }
        public string img2 { get; set; }
        public string id_restaurante { get; set; }
    }
}
