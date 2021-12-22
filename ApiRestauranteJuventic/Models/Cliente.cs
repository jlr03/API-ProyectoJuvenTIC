using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Cliente
    {
        public int id { get; set; }
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string correo { get; set; }
    }
}
