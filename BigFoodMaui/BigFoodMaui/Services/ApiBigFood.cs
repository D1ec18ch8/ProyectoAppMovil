using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodMaui.Services
{
    public class ApiBigFood
    {
        public HttpClient IniciarApi()
        {
            var cliente = new HttpClient();

            cliente.BaseAddress = new Uri("http://BIGFOODProyecto.somee.com/");

            return cliente;
        }
    }
}
