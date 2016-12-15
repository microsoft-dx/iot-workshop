using CloudTelemetry.Common;
using Newtonsoft.Json;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CloudTelemetry.SenseHat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private SenseHat _senseHat { get; set; }
        private IoTHubConnection _iotHubConnection { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            _senseHat = new SenseHat();
            _iotHubConnection = new IoTHubConnection();

            this.ActivateSenseHat();

            this.Loaded += (sender, e) =>
            {
                DispatcherTimer timer = new DispatcherTimer();

                timer.Tick += async (x, y) =>
                {
                    var temperatureTelemetry = _senseHat.GetTemperature();
                    this.temperatureBlock.Text = "Temperature: " + temperatureTelemetry.Temperature.ToString();
                    await _iotHubConnection.SendEventAsync(JsonConvert.SerializeObject(temperatureTelemetry));
                };

                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Start();
            };
        }

        private async void ActivateSenseHat()
        {
            await _senseHat.Activate();
        }
    }
}
