Session 3 - Sending Device-to-Cloud messages
============================================

In this session we will start building an application that sends data to an Azure IoT Hub.

Creating an Azure IoT Hub
--------------------------

First of all, you need to create an Azure IoT Hub. In order to do this, [follow this detailed step-by-step tutorial](../../common/azure-iot-hub.md).

After you created the IoT Hub, should see something similar to this:

![](../../common/media/iot-hub.JPG)


Installing the Device Explorer
------------------------------

[Device Explorer](https://github.com/Azure/azure-iot-sdks/releases/download/2016-11-17/SetupDeviceExplorer.msi) is a small application that allows the management and monitoring of the devices connected to an Azure IoT Hub.

After installing the application, start it, paste the **Connection string - primary key** in the connection string field from the **Configuration** tab and press the **Update** button.

![](../media/device-eplorer-connection.JPG)

Then, in the **Management** tab click **Create** button to create a new device identity. Provide a device id or name, optionally modify the primary and secondary key and click **Create**. 

![](../media/device-explorer-device.JPG)

At this point, we can copy the **Connection string** that was created for our device and use it later in our application.

![](../media/device-eplorer-string.JPG)

Unless we have this connection string that is associated with our IoT Hub instance, we will not be able to send data to the IoT Hub.

> There is also a [Node command line interface called iothub-explorer](https://github.com/Azure/iothub-explorer) that allows you to manage IoT Hub instances that we will use in Linux/Mac environments whwre the Device Exploerer application is not available. While you can also use it in Windows environments, it is recommended that you use the Device Explorer.

Create a UWP application that sends data to the IoT Hub
-------------------------------------------------------

In Visual Studio, create a **New Project** and under **Visual C#** choose the **Universal** tab. From there, choose the **Blank App(Universal Windows)** and press **Ok**.

![](../media/new-uwp-app.JPG)

A new dialog appears prompting you to choose the minimum and the target version of Windows for your application. You can leave the default values and press **Ok**.

![](../media/uwp-target-version.JPG)

At this point, we will use a [Visual Studio Extension called **Connected Service for Azure IoT Hub**](http://aka.ms/azure-iot-hub-vs-cs-vs-gallery). Install the extension, then right click on the **References** section from **Solution Explorer**.

![](../media/add-connected-service.JPG)

Then, select **Azure IoT Hub**.

![](../media/connected-service-iot-hub.JPG)

A dialog appears asking you to choose how to retrieve the connection string for thre communication between the application and the IoT Hub. At this point, we will use the Hardcoded option, since the option that retrieves the connection string stored on the device is still experimental.

![](../media/connected-service-security.JPG)

Reenter your credentials if prompted, then select the IoT Hub you just created.

> Notice that in this window you will see all instances of IoT Hub you created across your subscriptions.

![](../media/connected-service-choose-hub.JPG)

After you choose the IoT Hub instance, you are prompted to either choose an existing device associated with the IoT Hub or create a new device. You can do both, but since we created a device earlier, we will use it.

![](../media/connected-service-choose-device.JPG)

The Visual Studio extension will install a bunch of NuGet packages required for the communication with the IoT Hub.

![](../media/connected-service-added-items.JPG)

Together with the packages, this also adds a class called `AzureIoTHub.cs`.

![](../media/azure-iothub-cs.JPG)

This is only a very simple demo and we will not use it. In fact, we will delete this class and add a new one called `IoTHubConnection`.

```
    public class IoTHubConnection : IDisposable
    {
        private DeviceClient _deviceClient { get; set; }

        public IoTHubConnection()
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(GetConnectionString(), TransportType.Amqp));
        }

        public async Task SendEventAsync(string payload)
        {
            await _deviceClient.SendEventAsync(new Message(Encoding.ASCII.GetBytes(payload)));
        }

        private string GetConnectionString()
        {
            return "your-device-connection-string";
        }

        public void Dispose()
        {
            _deviceClient.Dispose();
        }
    }
```

This is a very simple implementation of a class that has a method that sends a `string` payload to an Azure IoT Hub. Notice that it implements the `IDisposable` interface since the `DeviceClient` class also implements it and we are using an instance of the `DeviceClient` class.

Then, in the `MainPage.xaml` add a `TextBlock` in the center of the screen.

```
<TextBlock x:Name="randomTextBlock" HorizontalAlignment="Center" TextWrapping="Wrap" Text="Placeholder" VerticalAlignment="Center"/>
```

![](../media/text-block.JPG)


Then, in `MainPage.xaml.cs` add an event handler for the `Loaded` event that fires up when the page finised loading. In this event handler we will create a timer and every 3 seconds we will send a string to the IoT Hub.

```
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
                        this.randomTextBlock.Text = message;
                    }
                };

                timer.Interval = TimeSpan.FromSeconds(3);
                timer.Start();
            };       
        }
    }
```

First we will run the application on the laptop and see if it really works. To verify, start the Device Exploerer application again and press the **Monitor** button under the **Data** tab and the application will start monitoring all messages that arrive from the device to IoT Hub. 

![](../media/uwp-local-device-explorer.JPG)