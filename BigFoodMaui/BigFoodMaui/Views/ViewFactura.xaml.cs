using BigFoodMaui.Model;
using BigFoodMaui.Services;

namespace BigFoodMaui.Views;

public partial class ViewFactura : ContentPage
{
    // Instancia del servicio para interactuar con la API.
    private readonly ApiService _apiService = new();
    // Almacena el token de autenticaci�n recibido al iniciar sesi�n.
    private readonly string _token;

    // Recibe el token de autenticaci�n necesario para cargar las facturas.
    public ViewFactura(string token)
    {
        InitializeComponent(); 
        _token = token;      // Guarda el token recibido.
        CargarFacturas();    // Llama al m�todo para cargar las facturas al iniciar la vista.
    }

    // M�todo as�ncrono para cargar las facturas desde la API.
    private async void CargarFacturas()
    {
        // Obtiene la lista de facturas usando el servicio API y el token.
        var facturas = await _apiService.ObtenerFacturasAsync(_token);

        // Verifica si se encontraron facturas.
        if (facturas != null && facturas.Count > 0)
        {
            // Asigna la lista de facturas a la fuente de datos del CollectionView.
            facturasList.ItemsSource = facturas;
        }
        else
        {
            // Muestra una alerta si no se encontraron facturas.
            await DisplayAlert("Aviso", "No se encontraron facturas.", "OK");
        }
    }
}