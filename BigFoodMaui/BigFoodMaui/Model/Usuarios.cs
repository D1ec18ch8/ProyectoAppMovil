using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodMaui.Model
{
    //Clase usuario con sus atributos
    public class Usuarios
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string estado { get; set; }
    }
}
