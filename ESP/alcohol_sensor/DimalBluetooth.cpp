#include "DimalBluetooth.h"
#ifndef ARDUINO_H
#define ARDUINO_H
  #include <Arduino.h>
#endif

Bluetooth::Bluetooth(){
  baud_rate = 9600;
  bluetooth_module = new SoftwareSerial(rx_pin,tx_pin);
}

Bluetooth::Bluetooth(int baud_rate, int rx_pin, int tx_pin){
  this->baud_rate = baud_rate;
  this->rx_pin = rx_pin;
  this->tx_pin = tx_pin;
  bluetooth_module = new SoftwareSerial(this->rx_pin, this->tx_pin);
}

void Bluetooth::start() {
  if(baud_rate <= 0)
    return;

  Serial.begin(baud_rate);
  bluetooth_module->begin(baud_rate);
  bluetooth_module->setTimeout(1000);
}

void Bluetooth::send(const char* data){
  Serial.println(data);
  bluetooth_module->println(data);
}

void Bluetooth::send(float data){
  Serial.println(data);
  bluetooth_module->println(data);
}

void Bluetooth::send(String data) {
  Serial.println(data);
  bluetooth_module->print(data);
}

String Bluetooth::receive() {
  String receivedData = "";
  while (bluetooth_module->available()) {
    char c = bluetooth_module->read();
    receivedData += c;
  }
  return receivedData;
}
