using BigFoodMaui.Services;
using BigFoodMaui.Model;

namespace BigFoodMaui.Views;

public partial class ViewLogin : ContentPage
{
    private readonly ApiService _apiService = new();
    public ViewLogin()
	{
		InitializeComponent();
	}
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
        {
            await DisplayAlert("Error", "Favor de llenar ambos campos.", "OK");
            return;
        }

        var usuario = new Usuarios
        {
            id = 0,
            login = txtUser.Text,
            password = txtPass.Text,
            fechaRegistro = DateTime.Now,
            estado = ""
        };

        string token = await _apiService.AutenticarAsync(usuario);

        if (!string.IsNullOrEmpty(token))
        {
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            await Navigation.PushAsync(new ViewFactura(token));
        }
        else
        {
            await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            txtUser.Text = "";
            txtPass.Text = "";
        }
    }
}