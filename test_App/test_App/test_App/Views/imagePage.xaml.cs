using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_App.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace test_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
        }

        public ImagePage(ItemTappedEventArgs e, string login, string password)
        {
            BindingContext = new ImageViewModel(e, login, password);
        }
    }
}