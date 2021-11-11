using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(server.Text) || string.IsNullOrEmpty(login.Text))
            {
                //_ = DisplayAlert("Пустые значения", "Введите сервер, логин и пароль", "OK");
                //await Navigation.PushAsync(new ChannelsPage("192.168.100.53:8080", "root", ""));
                await Navigation.PushAsync(new ChannelsPage("demo.macroscop.com", "root", ""));
            }
            else
            {
                await Navigation.PushAsync(new ChannelsPage(server.Text, login.Text, password.Text));
            }
        }
    }
}