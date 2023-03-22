#define SERIAL_NUMBER "ALC_00001"
#include "DimalCurve.h"
#include "DimalMq3Sensor.h"
// #include "DimalList.cpp"
#include "DimalQueue.cpp"
#include "DimalBluetooth.h"
#include <LiquidCrystal_I2C.h>
#include "DimalLcd.h"
#include <stdio.h>
#include <stdlib.h>
#include <time.h>
#include <string.h>

// Create LCD Object.
Lcd lcd(0x3F, 20, 4);

// Create Bluetooth Object.
Bluetooth bluetooth;

// Create Mq3 Object.
AlcoholSensor alcohol_sensor;

// Button Switch
const int switchPin = PD3;
const int greenLedPin = PD5;
const int redLedPin = PD6;
const int btStatePin = PD7;

float sensorValue = 0.0f;
float sensorVolt = 0.0f;

List<int> sensorValues;

Queue<int> calculations;

int limit = 200;

void setup() 
{
  // Initialise the Standard Output
  Serial.begin(9600);

  pinMode(switchPin, INPUT_PULLUP);
  pinMode(greenLedPin, OUTPUT);
  pinMode(redLedPin, OUTPUT);
  pinMode(btStatePin, INPUT);

  // Starts the LCD Module
  lcd.start();
  digitalWrite(greenLedPin, HIGH);
  digitalWrite(redLedPin, HIGH);
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
  for(int timer = 0; timer < 20; timer++){
    lcd.print("*", timer, 1);
    limit += alcohol_sensor.receiveAnalogData();
    delay(1000);
  }

  limit /= 20; // get the average
  limit = limit + 100;
  limit += (limit * 0.05);

  Serial.println(limit);
  lcd.clear();
  lcd.print("Initialise", 5, 0);
  delay(3000);
  lcd.print("Completed", 2, 0);
  lcd.clear();
  lcd.backlight(false);
}

void loop() {

  //Serial.println(alcohol_sensor.receiveAnalogData());
  /*
  * If bluetooth is connected then bluetooth module starts send the values from Queue
  * and continues until the state become LOW again.
  */
  if(digitalRead(btStatePin) == HIGH) {
    
    if(!calculations.IsEmpty()) {
      int value_from_queue = calculations.Peek();
      calculations.Dequeue();
      
      String r = SERIAL_NUMBER + String("|");
      r = r + String(value_from_queue) + String(",");

      bluetooth.send(r);
    }
  }
  
  /*
  * Using Button in order to get values from Alcohol Sensor it means you reiceive rapidly data.
  * These data you need to be calculated before send it to mobile.
  * For this reason we save all values into a list and after that we will search for the highest value. This value is the correct value.
  * The highest value is added to queue in order to send it via Bluetooth when Bluetooth Connection is available.
  * If this value is greater than limit the Red Led must lights up else Green Led lights up.
  */

  bool buttonIsPressed = (digitalRead(switchPin) == LOW ? true : false);
  
  if(buttonIsPressed)
  {
    sensorValues.clear();
    int counter = 0;
    lcd.backlight(buttonIsPressed);
    lcd.clear();
    
    lcd.print("Please Breath...", 2, 0);
    
    do {
      //Read the value from Sensor.
      int bits = alcohol_sensor.receiveAnalogData();
      
      // lcd.print("Bits: ", 0, 0);
      // lcd.print(bits, 8, 0);
      sensorVolt = (bits * 5.0f) / 1023.0f;
      // lcd.print("Volt: ", 0, 1);
      // lcd.print(sensorVolt, 8, 1);

      float result = map(sensorVolt, 0.0f, 5.0f, 25.0f, 500.0f);
      // lcd.print("Map: ", 0, 2);
      // lcd.print(result, 7, 2);

      // Add to list
      sensorValues.add(bits);

      counter++;

      lcd.print(counter, 5, 1);
      lcd.print(" sec", 7, 1);

      delay(1000);
    } while(counter < 10);
  }
  
  if (buttonIsPressed)
  {

    int max_value = sensorValues.max_value(); // Getting the Max Value.
    calculations.Enqueue(max_value); // Enqueue the Max Value.

    lcd.clear();
    lcd.print("OK Thank you!!!", 2, 0);
    delay(2000);
    lcd.clear();
    lcd.print("Based on Calc.", 3, 0);
    lcd.print("You are: ", 3, 1);

    if(max_value <= limit) {
      lcd.print("Sober", 11, 1);
      lcd.print("Driving", 5, 2);
      lcd.print("is allowed", 3, 3);
      digitalWrite(greenLedPin, LOW);
    }
    else {
      digitalWrite(redLedPin, LOW);
      lcd.print("Drunk", 11, 1);
      lcd.print("Driving", 5, 2);
      lcd.print("is prohibited",3, 3);
    }
    delay(5000);
  }

  buttonIsPressed = false;
  lcd.backlight(buttonIsPressed);
  sensorValues.clear();

  lcd.clear();
}