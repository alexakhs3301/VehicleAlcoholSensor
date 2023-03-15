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
  Serial.begin(9600);
  Serial.println("Hello World");
  lcd.start();
  // lcd.print("Starting Bluetooth", 1, 0);
  bluetooth.start();
  // delay(5000);
  // lcd.clear();
  // lcd.print("Bluetooth Started",1,0);
  // delay(5000);
  // lcd.clear();
  // lcd.print("Mq3 Warming Up", 2, 0);
  // alcohol_sensor.start();
  // delay(5000);
  // lcd.clear();
  // lcd.print("Initialise", 9, 0);
  // lcd.print("Completed", 10, 0);
  // lcd.clear();
}

void loop() {

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

  lcd.clear();
  int adcValue = alcohol_sensor.receiveAnalogData();
  // float voltage =  (adcValue * 3.3) / 1023.0;
  //float voltage = (adcValue / 10) * (5.0 / 1023.0);

  long ppm = map(adcValue, 0, 1023, 0, 500);
  


  bluetooth.send(ppm);
  lcd.print(ppm, 0, 0);
  delay(1000);

}