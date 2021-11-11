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

        //private HttpClient httpClient = new HttpClient();
        private static string urlGetchannelsstates;
        private static string urlConfigex;

        //private static string urlGetchannelsstates = "http://demo.macroscop.com//command?type=getchannelsstates&login=root&password=";
        //private static string urlConfigex = "http://demo.macroscop.com/configex?login=root&password=";
        public ChannelsViewModel(string server, string login, string password)
        {
            urlGetchannelsstates = "http://" + server + "//command?type=getchannelsstates&" + "login=" + login + "&password=" + password;
            urlConfigex = "http://" + server + "/configex?login=" + login + "&password=" + password;
            ChannelInfo_ = new Dictionary<string, ChannelInfo>();
            Cameras = new ObservableCollection<ChannelInfo>();
            GetChannels();
        }

        public ChannelsViewModel() { }

        private async void GetChannels()
        {
            try
            {
                DataSerializer dataSerializer = new DataSerializer();
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlGetchannelsstates);
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Encoding", "identity");
                var client = new HttpClient();
                HttpResponseMessage response = await client.SendAsync(request);
                HttpContent content = response.Content;
                string xmlResponse = await content.ReadAsStringAsync();

                ArrayOfChannelState arrayOfChannelState = (ArrayOfChannelState)dataSerializer.XmlDeserialize(typeof(ArrayOfChannelState), xmlResponse);

                request = new HttpRequestMessage();
                request.RequestUri = new Uri(urlConfigex);
                request.Method = HttpMethod.Get;
                request.Headers.Add("Accept", "application/xml");
                request.Headers.Add("Accept-Encoding", "identity");
                client = new HttpClient();
                response = await client.SendAsync(request);
                content = response.Content;
                xmlResponse = await content.ReadAsStringAsync();

                Channels channels = (Channels)dataSerializer.XmlDeserialize(typeof(Channels), xmlResponse);

                const string imgYesUrl = "https://v.fastcdn.co/u/39356145/50683595-0-noun-tick-2103587.png";
                const string imgNoUrl = "https://smmis.ru/wp-content/uploads/2015/05/skritie-1024x1024.jpg";

                await Task.Run(() =>
                {
                    foreach (ChannelInfo item in channels.channelInfo)
                    {
                        if (item.IsDisabled == "false")
                            ChannelInfo_.Add(item.Id, item);
                    }
                    foreach (ChannelState item in arrayOfChannelState.ChannelState)
                    {
                        ChannelInfo_[item.Id].IsRecordingOn = item.IsRecordingOn;
                        ChannelInfo_[item.Id].Streams = item.StreamsStates.Stream;
                    }
                    foreach (var item in ChannelInfo_.Values)
                    {
                        item.IsSoundOnImage = item.IsSoundOn == "true" ? imgYesUrl : imgNoUrl;
                        item.IsRecordingOnImage = item.IsRecordingOn == "true" ? imgYesUrl : imgNoUrl;
                        Application.Current.Dispatcher.BeginInvokeOnMainThread((Action)(() => Cameras.Add(item)));
                    }
                });
            }
            catch (Exception e)
            {
                GetChannels(); //ересь, но все же
            }
        }
    }
}
