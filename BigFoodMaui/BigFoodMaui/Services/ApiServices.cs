using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using BigFoodMaui.Model;
using Newtonsoft.Json;
using BigFoodMaui.Services;
namespace BigFoodMaui.Services
{
    public class ApiService
    {
        private readonly HttpClient _api; // Cliente HTTP para las solicitudes a la API.

        public ApiService()
        {
            var clienteApi = new ApiBigFood(); // Instancia para obtener el cliente API configurado.
            _api = clienteApi.IniciarApi();    // Obtiene el cliente HTTP.
        }

        // Autentica un usuario y devuelve un token de seguridad.
        public async Task<string> AutenticarAsync(Usuarios usuarios)
        {
            var json = JsonConvert.SerializeObject(usuarios); // Serializa el objeto de usuario a JSON.
            var content = new StringContent(json, Encoding.UTF8, "application/json"); // Crea el contenido de la solicitud.

            HttpResponseMessage response = await _api.PostAsync("Usuarios/Autentificar", content); // Envía la solicitud POST.

            if (!response.IsSuccessStatusCode) // Si la solicitud no fue exitosa, devuelve null.
                return null;

            string mensaje = await response.Content.ReadAsStringAsync(); // Lee el contenido de la respuesta.
            AuthResponse resp = JsonConvert.DeserializeObject<AuthResponse>(mensaje)!; // Deserializa la respuesta a AuthResponse.
            return resp.Token; // Devuelve el token de autenticación.
        }

        // Obtiene una lista de facturas desde la API.
        public async Task<List<Facturas>> ObtenerFacturasAsync(string token)
        {
            // Agrega el token de autorización a los encabezados de la solicitud.
            _api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _api.GetAsync("Facturas/Listar_Facturas"); // Envía la solicitud GET.

            if (!response.IsSuccessStatusCode) // Si la solicitud no fue exitosa, devuelve una lista vacía.
                return new List<Facturas>();

            string json = await response.Content.ReadAsStringAsync(); // Lee el contenido JSON de la respuesta.
            return JsonConvert.DeserializeObject<List<Facturas>>(json)!; // Deserializa el JSON a una lista de Facturas.
        }
    }
}