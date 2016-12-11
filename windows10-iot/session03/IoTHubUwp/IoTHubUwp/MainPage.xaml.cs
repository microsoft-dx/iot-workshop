using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace IoTHubUwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.Loaded += (sender, eventArgs) =>
            {
                DispatcherTimer timer = new DispatcherTimer();

                timer.Tick += async (s, e) =>
                {
                    using (var iotHubConnection = new IoTHubConnection())
                    {
                        var message = $"Random string at {DateTime.Now}";
                        await iotHubConnection.SendEventAsync(message);
                        this.randomTextBlock.Text += "\n" + message;
                    }
                };

                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Start();
            };       
        }
    }
}
