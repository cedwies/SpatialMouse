# PhysComp SS24 - SpatialMouse - Software

This section contains the code for the Arduino Nano ESP32. The code operates a Bluetooth mouse featuring two buttons, a scroll switch, and a mouse sensor. The mouse sensor detects whether the device is on the ground or in the air and transmits this information to another Bluetooth device. When the mouse is lifted, the buttons have alternative functions and do not operate as standard mouse clicks.

We worked with code from here (for our mouse sensor): 
https://github.com/mrjohnk/PMW3389DM

And with the BLE Mouse Library:
https://github.com/T-vK/ESP32-BLE-Mouse
