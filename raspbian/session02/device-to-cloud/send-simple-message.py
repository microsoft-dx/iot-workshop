from datetime import datetime
from deviceClient import DeviceClient


KEY = "device-primary-key";
HUB = "iot-hub-name";
DEVICE_NAME = "device-name";


device = DeviceClient(HUB, DEVICE_NAME, KEY)
device.create_sas(600)

time = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
message = "Hello at {0}, this is awesome!".format(time)

print(device.send(str.encode(message)))