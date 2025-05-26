using Microsoft.Maui.Controls;

namespace Quick_Kids_Quiz
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();  // This hooks up the XAML UI components.

            MainPage = new NavigationPage(new MainMenuPage());  // Your main page here
        }
    }
}
