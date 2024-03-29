#ifndef ARDUINO_H
#define ARDUINO_H
  #include <Arduino.h>
#endif
class AlcoholSensor {
  public:
    AlcoholSensor();
    AlcoholSensor(int analog_pin, int digital_pin);

    void start();
    void stop();
    int receiveAnalogData();
    bool receiveDigitalData();

  private:
    int analog_pin = A0;
    int digital_pin = PD4;
    bool is_started = false;
};