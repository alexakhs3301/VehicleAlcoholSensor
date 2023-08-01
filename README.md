# **Vehicle Alcohol Sensor Project**

This project is designed to prevent drunk driving by using an ESP8266 microcontroller(or ARDUINO UNO), MQ3 alcohol sensor, and Bluetooth module to detect the concentration of alcohol in the user's breath. The results are displayed on an LCD screen on the breadboard, as well as on a mobile app made with Xamarin.


## **Hardware Components**

#### ESP8266 microcontroller
#### MQ3 alcohol sensor
#### Bluetooth module
#### LCD screen
#### Breadboard
#### Jumper wires




## **Software Components**

#### Arduino IDE (to program the ESP8266 microcontroller)
#### Xamarin app development platform (for building the mobile app)
#### Go programming language (for writing the API)
#### PostgreSQL database (for storing data from the API)



## **Features**

#### Detects the concentration of alcohol in the user's breath
#### Displays the alcohol concentration on an LCD screen and on a mobile app
#### Prevents the vehicle's engine from starting if the alcohol concentration is above a predetermined limit
#### Stores data on the user's alcohol concentration in a Postgres database through an API written in Go



## **Setup**

#### Connect the ESP8266 microcontroller, MQ3 alcohol sensor, and Bluetooth module to the breadboard according to the circuit diagram.
#### Install the mobile app on your smartphone and connect to the Bluetooth module.
#### Run the API and database setup instructions.
#### Turn on the vehicle and blow into the alcohol sensor. The LCD screen and mobile app will display the alcohol concentration, and the engine will only start if the concentration is below the predetermined limit.



## **Maintenance**

#### 1. Regularly check and replace the MQ3 alcohol sensor as needed.
#### 2. Keep the Bluetooth module and mobile app up to date.
#### 3. Periodically check the API and database for errors and ensure that data is being properly stored and retrieved.



## **Mobile app**

#### To use the mobile app, you will need a device with Bluetooth capabilities and the Xamarin app installed. Once the app is installed and the circuit is set up, you can pair your device with the Bluetooth module by following the standard Bluetooth pairing process.

#### Once paired, you can use the app to see the current alcohol concentration as detected by the MQ3 sensor and to control the engine of the vehicle. The app will also send data to the API, which will store it in the PostgreSQL database.



## **API**

#### The API is written in Go and provides endpoints for getting and posting data to the PostgreSQL database. It can be run on a server and accessed via HTTP requests.



## **Usage**

### To use the Alcohol Detection and Engine Control System, follow these steps:

#### - Set up the circuit as described above.
#### - Install and run the mobile app on your device.
#### - Pair your device with the Bluetooth module.
#### - Start the API on a server.
#### - Before starting the vehicle, blow into the alcohol sensor.
#### - The alcohol concentration will be displayed on the LCD screen and on the mobile app.
#### - If the concentration is below the predetermined limit, the vehicle's engine will start as usual.
#### - If the concentration is above the limit, the vehicle's engine will not start and a warning message will be displayed on the LCD screen and mobile app.



## **Safety**

#### It is important to always use this project responsibly and never drink and drive. The alcohol sensor and vehicle engine disabling feature are meant to be an added safety precaution, not a replacement for responsible behavior.



## **Customization**

#### The predetermined alcohol concentration limit can be adjusted in the code. It is important to consult with local laws and regulations before making any changes.



## **Disclaimer**

#### **This project is intended for educational and demonstration purposes only and should not be used as a substitute for proper safety measures when operating a vehicle. It is the responsibility of the user to ensure that they are not impaired by alcohol or any other substance while driving.**



## **Additional Resources**

[ESP8266 Microcontroller Documentation](https://arduino-esp8266.readthedocs.io/en/latest/)

[MQ3 Alcohol Sensor Datasheet](https://www.sparkfun.com/datasheets/Sensors/MQ-3.pdf)

[Bluetooth Module Documentation](https://components101.com/sites/default/files/component_datasheet/HC-05%20Datasheet.pdf)

[Xamarin Documentation](https://learn.microsoft.com/en-us/xamarin/)

[Go Documentation](https://go.dev/doc/)

[Postgres Documentation](https://www.postgresql.org/docs/)
