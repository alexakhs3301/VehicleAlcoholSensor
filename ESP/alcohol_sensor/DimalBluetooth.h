#include <string.h>
#include <SoftwareSerial.h>

class Bluetooth {
  public:
    Bluetooth();
    Bluetooth(int baud_rate, int rx_pin, int tx_pin);
    void start();
    void send(const char* data);
    void send(float data);
    String receive(); 

  private:
    int baud_rate = 9600;
    int rx_pin = 3;
    int tx_pin = 1;
    SoftwareSerial* bluetooth_module;
};
