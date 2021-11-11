using System;
using System.IO;
using System.Net.Http;
using System.Text;
using test_App.Models;
using Xamarin.Forms;

namespace test_App.ViewModels
{
    class ImageViewModel
    {
        public string Image { get; set; }
        private static string urlGetImage;
        ItemTappedEventArgs e;
        string login;
        string password;
        public ImageViewModel(ItemTappedEventArgs e, string login, string password)
        {
            this.e = e;
            this.login = login;
            this.password = password;
            GetImage();
        }

        private async void GetImage()
        {
            try
            {
                var channelInfo = e.Item as ChannelInfo;
                string id = channelInfo.Id;
                urlGetImage = "http://demo.macroscop.com/mobile?channelid=" + id + "&login=" + login + "&password=" + password + "&oneframeonly=true";
                var client = new HttpClient();
                string response = await client.GetStringAsync(urlGetImage);
                for (int i = 0; i < 6; i++)
                {
                    int index = response.IndexOf("\n");
                    response = response.Substring(index).Trim();
                }
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string filePath = Path.Combine(documentsPath, "image.jpg");
                byte[] data = Encoding.ASCII.GetBytes(response);
                File.WriteAllBytes(filePath, data);
                var filesList = Directory.GetFiles(documentsPath);
            }
            catch (Exception e)
            {

            }
        }
    }
}
