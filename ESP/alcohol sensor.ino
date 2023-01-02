#include <math.h>
#include <Arduino.h>
#include <ESP8266WiFi.h>

#include "DimalCurve.h"
#include "DimalMq3Sensor.h"
#include "DimalQueue.h"

Queue _queue;

void setup() 
{
  init_queue(&_queue, sizeof(float));

  InitializeLeastSquares();
  InitMq3Sensor();

  Serial.begin(9600);
}

void loop() {

  float result = Mq3SensorData();
  enqueue(&_queue, &result);
  Serial.println(result);
  
  delay(3000);
}

