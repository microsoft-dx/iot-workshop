from deviceClient import DeviceClient

KEY = "device-primary-key";
HUB = "iot-hub-name";
DEVICE_NAME = "device-name";


device = DeviceClient(HUB, DEVICE_NAME, KEY)
device.create_sas(600)

print(device.send(b"{message: 'This is awesome! Hello from Python!'}"))
