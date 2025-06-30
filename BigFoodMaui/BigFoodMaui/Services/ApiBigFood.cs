using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigFoodMaui.Services
{
    public class ApiBigFood
    {
        // Crea y configura un cliente HttpClient para interactuar con la API.
        public HttpClient IniciarApi()
        {
            // Crea una nueva instancia de HttpClient.
            var cliente = new HttpClient();

            // Establece la dirección base de la API.
            cliente.BaseAddress = new Uri("http://BIGFOODProyecto.somee.com/");

            // Devuelve el cliente HttpClient configurado.
            return cliente;
        }
    }
}
