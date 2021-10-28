using test_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StreamsPage : ContentPage
    {
        public StreamsPage()
        {
            InitializeComponent();
        }

        public StreamsPage(ItemTappedEventArgs e)
        {
            InitializeComponent();
            BindingContext = new StreamsViewModel(e);
        }
    }
}