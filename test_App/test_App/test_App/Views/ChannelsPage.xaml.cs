using test_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelsPage : ContentPage
    {
        public ChannelsPage()
        {
            InitializeComponent();
            BindingContext = new ChannelsViewModel();
        }

        private async void OnItemSelected(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new StreamsPage(e));
        }
    }
}