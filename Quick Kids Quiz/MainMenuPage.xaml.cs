using System;
using Microsoft.Maui.Controls;

namespace Quick_Kids_Quiz // <--- This must match the namespace in your project
{
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private async void OnStartClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnAboutClicked(object sender, EventArgs e)
        {
            await DisplayAlert("About", "Quick Kids Quiz helps kids learn through fun quizzes!", "OK");
        }
    }
}
