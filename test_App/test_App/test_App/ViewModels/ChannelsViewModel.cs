using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using test_App.Models;
using Xamarin.Forms;

namespace test_App.ViewModels
{
    class ChannelsViewModel
    {
        public ObservableCollection<ChannelInfo> Cameras { get; set; }
        public Dictionary<string, ChannelInfo> ChannelInfo_ { get; set; }

        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string urlGetchannelsstates = "http://demo.macroscop.com//command?type=getchannelsstates&login=root&password=";
        private static readonly string urlConfigex = "http://demo.macroscop.com/configex?login=root&password=";

        public ChannelsViewModel()
        {
            ChannelInfo_ = new Dictionary<string, ChannelInfo>();
            Cameras = new ObservableCollection<ChannelInfo>();
            GetChannels();
        }

        private async void GetChannels()
        {
            DataSerializer dataSerializer = new DataSerializer();
            HttpResponseMessage response = await httpClient.GetAsync(urlConfigex);
            Channels channels = (Channels)dataSerializer.XmlDeserialize(typeof(Channels), await response.Content.ReadAsStringAsync());

            response = await httpClient.GetAsync(urlGetchannelsstates);
            ArrayOfChannelState arrayOfChannelState = (ArrayOfChannelState)dataSerializer.XmlDeserialize(typeof(ArrayOfChannelState), await response.Content.ReadAsStringAsync());

            const string imgYesUrl = "https://cdn-icons.flaticon.com/png/512/3106/premium/3106690.png?token=exp=1635443444~hmac=b5bb0d89db3f24f14d0d491e284ea605";
            const string imgNoUrl = "https://cdn-icons.flaticon.com/png/512/4013/premium/4013407.png?token=exp=1635443709~hmac=272ed4bb77aace9935409c807341110c";

            await Task.Run(() =>
            {
                foreach (ChannelInfo item in channels.channelInfo)
                {
                    ChannelInfo_.Add(item.Id, item);
                }
                foreach (ChannelState item in arrayOfChannelState.ChannelState)
                {
                    ChannelInfo_[item.Id].IsRecordingOn = item.IsRecordingOn;
                    ChannelInfo_[item.Id].Streams = item.StreamsStates.Stream;
                }
                foreach(var item in ChannelInfo_.Values)
                {
                    item.IsSoundOnImage = item.IsSoundOn == "true" ? imgYesUrl : imgNoUrl;
                    item.IsRecordingOnImage = item.IsRecordingOn == "true" ? imgYesUrl : imgNoUrl;
                    Application.Current.Dispatcher.BeginInvokeOnMainThread((Action)(() => Cameras.Add(item)));
                }
            });
        }
    }
}
