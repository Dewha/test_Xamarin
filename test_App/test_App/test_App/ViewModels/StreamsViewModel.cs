using System.Collections.ObjectModel;
using test_App.Models;
using Xamarin.Forms;

namespace test_App.ViewModels
{
    public class StreamsViewModel
    {
        public StreamsViewModel(ItemTappedEventArgs e)
        {
            ChannelInfo_ = e.Item as ChannelInfo;
            Streams = new ObservableCollection<Stream>();
            foreach (Stream item in ChannelInfo_.Streams)
            {
                if (item.State == "Active")
                    Streams.Add(item);
            }  
            if (Streams.Count == 0)
            {
                Streams.Add(new Stream("Активных потоков нет", ""));
            }
        }

        public StreamsViewModel()
        {

        }

        public ChannelInfo ChannelInfo_ { get; set; }
        public ObservableCollection<Stream> Streams { get; set; }
        
    }
}
