using BigFoodMaui.Services;
using BigFoodMaui.Model;

namespace BigFoodMaui.Views;

public partial class ViewLogin : ContentPage
{
    // Instancia del servicio para interactuar con la API.
    private readonly ApiService _apiService = new();

    // Constructor de la vista de inicio de sesión.
    public ViewLogin()
    {
        InitializeComponent(); 
    }

    // Manejador del evento Click del botón de inicio de sesión.
    private async void btnLogin_Clicked(object sender, EventArgs e)
    {
        // Verifica si los campos de usuario o contraseña están vacíos.
        if (string.IsNullOrWhiteSpace(txtUser.Text) || string.IsNullOrWhiteSpace(txtPass.Text))
        {
            // Muestra una alerta si falta algún campo.
            await DisplayAlert("Error", "Favor de llenar ambos campos.", "OK");
            return; // Sale del método.
        }

        // Crea un nuevo objeto Usuarios con los datos ingresados.
        var usuario = new Usuarios
        {
            id = 0,
            login = txtUser.Text, 
            password = txtPass.Text, 
            fechaRegistro = DateTime.Now, 
            estado = "" 
        };

        // Intenta autenticar al usuario con la API y obtiene un token.
        string token = await _apiService.AutenticarAsync(usuario);

        // Verifica si se recibió un token válido.
        if (!string.IsNullOrEmpty(token))
        {
            // Muestra mensaje de éxito.
            await DisplayAlert("Éxito", "Inicio de sesión correcto", "OK");
            // Navega a la vista de facturas, pasando el token.
            await Navigation.PushAsync(new ViewFactura(token));
        }
        else
        {
            // Muestra mensaje de error por credenciales incorrectas.
            await DisplayAlert("Error", "Credenciales incorrectas", "OK");
            // Limpia los campos de usuario y contraseña.
            txtUser.Text = "";
            txtPass.Text = "";
        }
    }
}