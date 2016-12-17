using CloudTelemetry.Common;
using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CloudTelemetry.Simulated
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private IoTHubConnection _iotHubConnection { get; set; }
        private Random _random { get; set; }
        public MainPage()
        {
            this.InitializeComponent();

            _iotHubConnection = new IoTHubConnection();
            _random = new Random();

            this.Loaded += (sender, routedEventArgs) =>
            {

                DispatcherTimer timer = new DispatcherTimer();
                timer.Tick += async (s, e) =>
                {
                    var temperatureTelemetry = new TemperatureTelemetry()
                    {
                        Time = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss.fff"),
                        Temperature = Math.Round(_random.NextDouble() * (40 - 20) + 20, 2)
                };

                    this.temperatureBlock.Text = $"Temperature: {temperatureTelemetry.Temperature.ToString()}";
                    await _iotHubConnection.SendEventAsync(JsonConvert.SerializeObject(temperatureTelemetry));
                };
                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Start();

            };
        }
    }
}
