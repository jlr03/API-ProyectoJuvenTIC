using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Reserva
    {
        public int id { get; set; }
        public int id_cliente { get; set; }
        public int id_servicio { get; set; }
        public string descripcion { get; set; }
        public DateTime fecha { get; set; }
    }
}
