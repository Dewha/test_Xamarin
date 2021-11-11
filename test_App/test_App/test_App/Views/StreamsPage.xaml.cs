using System;
using test_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StreamsPage : ContentPage
    {
        string login;
        string password;
        ItemTappedEventArgs e;
        public StreamsPage()
        {
            InitializeComponent();
        }

        public StreamsPage(ItemTappedEventArgs e, string login, string password)
        {
            InitializeComponent();
            this.login = login;
            this.password = password;
            this.e = e;
            BindingContext = new StreamsViewModel(e);
        }

        private async void OnGetImageButtonClicked(object sender, EventArgs ea)
        {
            await Navigation.PushAsync(new ImagePage(e, login, password));
        }
    }
}