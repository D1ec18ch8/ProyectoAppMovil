namespace BigFoodMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new BigFoodMaui.Views.ViewLogin());
        }
    }
}
