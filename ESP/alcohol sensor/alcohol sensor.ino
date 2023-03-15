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

void setup() 
{
  lcd.start();
  bluetooth.start();
}

void loop() {

  // float result = Mq3SensorData();
  // enqueue(&_queue, &result);
  // Serial.println(result);
  //send(&d);
  // lcd.setCursor(0, 0); 
  // lcd.print("Alcohol Percent:");

  lcd.print("Alcohol Percent:", 2, 0);

  srand((unsigned int) time(NULL));
  
  while(true){
    float d = ((float) rand() / (float)(RAND_MAX));
    lcd.print(d, 4, 1);
    lcd.print("mg/L", 10, 1);
    bluetooth.send(d);
    delay(3000);
    String received = bluetooth.receive();
    lcd.clear(2);
    lcd.print(received, 0, 2);

    delay(3000);
    lcd.backlight(false);
    delay(3000);
    lcd.backlight(true);
  }

}