using System;
using test_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelsPage : ContentPage
    {
        private string server;
        private string login;
        private string password;
        public ChannelsPage(string server, string login, string password)
        {
            InitializeComponent();
            this.server = server;
            this.login = login;
            this.password = password;
            BindingContext = new ChannelsViewModel(server, login, password);
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new StreamsPage(e, login, password));
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            BindingContext = new ChannelsViewModel(server, login, password);
        }
    }
}