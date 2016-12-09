from grovepi import *
from grove_rgb_lcd import *
import time

ultrasonic_ranger = 4

while True:
    try:
        distance = ultrasonicRead(ultrasonic_ranger)
        print(distance, 'cm')

        setRGB(0, 255, 0)
        text = "Distance: {} cm".format(distance)
        setText(text)
        time.sleep(.5)

    except KeyboardInterrupt:
        setRGB(255,0,0)
        setText("Keyboard Interrupt")
        time.sleep(2)
        setRGB(0,0,0)
        exit()
