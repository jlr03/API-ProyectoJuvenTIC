using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class PlatosPedido
    {
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int cantidad { get; set; }
    }
}
