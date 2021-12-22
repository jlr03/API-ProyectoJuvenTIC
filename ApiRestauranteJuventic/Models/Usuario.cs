using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestauranteJuventic.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public Boolean administrador { get; set; }
    }
}
