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
        private readonly HttpClient _api;

        public ApiService()
        {
            var clienteApi = new ApiBigFood();
            _api = clienteApi.IniciarApi();
        }

        public async Task<string> AutenticarAsync(Usuarios usuarios)
        {
            var json = JsonConvert.SerializeObject(usuarios);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _api.PostAsync("Usuarios/Autentificar", content);

            if (!response.IsSuccessStatusCode)
                return null;

            string mensaje = await response.Content.ReadAsStringAsync();
            AuthResponse resp = JsonConvert.DeserializeObject<AuthResponse>(mensaje)!;
            return resp.Token;
        }

        public async Task<List<Facturas>> ObtenerFacturasAsync(string token)
        {
            _api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await _api.GetAsync("Facturas/Listar_Facturas");

            if (!response.IsSuccessStatusCode)
                return new List<Facturas>();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Facturas>>(json)!;
        }
    }
}