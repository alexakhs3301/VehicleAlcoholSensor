#include "DimalMq3Sensor.h"

AlcoholSensor::AlcoholSensor(){}

AlcoholSensor::AlcoholSensor(int analog_pin, int digital_pin) {
  this->analog_pin = analog_pin;
  this->digital_pin = digital_pin;
}

void AlcoholSensor::start(){
    if(this->is_started)
      return;

    this->is_started = true;
}

void AlcoholSensor::stop(){
  if(!this->is_started)
    return;

  this->is_started = false;
}

int AlcoholSensor::receiveAnalogData() {
  int sensorValue = analogRead(analog_pin);
  return sensorValue;
}

bool AlcoholSensor::receiveDigitalData() {
  bool sensorValue = digitalRead(digital_pin);

  return sensorValue;
}