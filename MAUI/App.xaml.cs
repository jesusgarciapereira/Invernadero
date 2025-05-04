using MAUI.Views;

namespace MAUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Antes:
            // MainPage = new MainPage();

            // Ahora:
            MainPage = new NavigationPage(new SeleccionarInvernaderoPage());
        }
    }
}
