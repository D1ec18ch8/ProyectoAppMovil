using BigFoodMaui.Model;
using BigFoodMaui.Services;

namespace BigFoodMaui.Views;

public partial class ViewFactura : ContentPage
{
    private readonly ApiService _apiService = new();
    private readonly string _token;
    public ViewFactura(string token)
	{
		InitializeComponent();       
        _token = token;
        CargarFacturas();
    }
    private async void CargarFacturas()
    {
        var facturas = await _apiService.ObtenerFacturasAsync(_token);

        if (facturas != null && facturas.Count > 0)
        {
            facturasList.ItemsSource = facturas;
        }
        else
        {
            await DisplayAlert("Aviso", "No se encontraron facturas.", "OK");
        }
    }
}