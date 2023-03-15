#define ALCOHOL_LIMIT 0.25
#include "DimalCurve.h"
#include "DimalMq3Sensor.h"
#include "DimalQueue.h"
#include "DimalBluetooth.h"
#include <LiquidCrystal_I2C.h>

#include "DimalLcd.h"


#include <stdio.h>
#include <stdlib.h>
#include <time.h>

// Create LCD Object.
Lcd lcd(0x3F, 20, 4);

// Create Bluetooth Object.
Bluetooth bluetooth;

// Create Mq3 Object.
AlcoholSensor alcohol_sensor;

void setup() 
{
  // Initialise the Standard Output
  Serial.begin(9600);

  // Starts the LCD Module
  lcd.start();

  // Starts the Bluetooth Module
  lcd.print("Starting Bluetooth", 1, 0);
  bluetooth.start();
  delay(5000);
  lcd.clear();
  lcd.print("Bluetooth Started",1,0);
  delay(5000);
  lcd.clear();

  // Starts the Mq3
  lcd.print("Mq3 Warming Up", 2, 0);
  alcohol_sensor.start();
  delay(5000);
  lcd.clear();
  lcd.print("Initialise", 9, 0);
  delay(3000);
  lcd.print("Completed", 10, 0);
  lcd.clear();
}

void loop() {

  /*
  * 
  */


  lcd.clear();
  /*
  * Using Button in order to get values from Alcohol Sensor it means you reiceive rapidly data.
  * These data you need to be calculated before send it to mobile.
  * For this reason we save all values into a list and after that we search for the highest value. This value is the correct value.
  * If this value is greater than limit, the led should not lights otherwise the led should lights.
  */

  bool btn_ispressed = true;

  while(btn_ispressed)
  {
    // Read the value from Sensor.
    int adcValue = alcohol_sensor.receiveAnalogData();
    // We must convert the analog signal to PPM.
    long ppm = map(adcValue, 0, 1023, 0, 500);
    //Save this value to list.

    // Check if button is not currently pressed
  }


  // Getting the Maximun Value in List
  float mgpb = 2.5;

  // Check if the value is in limit.
  if(mgpd >= ALCOHOL_LIMIT) {
    // Should not light up the led.
  }
  else {
    // Should light up the led.
  }


  // float result = Mq3SensorData();
  // enqueue(&_queue, &result);
  // Serial.println(result);
  //send(&d);
  // lcd.setCursor(0, 0); 
  // lcd.print("Alcohol Percent:");

  // lcd.print("Alcohol Percent:", 2, 0);

  // srand((unsigned int) time(NULL));
  
  // while(true){
  //   float d = ((float) rand() / (float)(RAND_MAX));
  //   lcd.print(d, 4, 1);
  //   lcd.print("mg/L", 10, 1);
  //   bluetooth.send(d);
  //   delay(3000);
  // }

  // float voltage =  (adcValue * 3.3) / 1023.0;
  //float voltage = (adcValue / 10) * (5.0 / 1023.0);

  


  bluetooth.send(ppm);
  lcd.print(ppm, 0, 0);
  delay(1000);

}