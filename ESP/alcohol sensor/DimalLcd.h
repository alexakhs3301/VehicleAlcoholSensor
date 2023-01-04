#include <LiquidCrystal_I2C.h>

class Lcd {
  public:
    Lcd(uint8_t lcd_address, int lcd_cols, int lcd_rows);
    Lcd();
    void start();
    void print(const char* printData, int print_to_column, int print_to_row);
    void print(float printData, int print_to_column, int print_to_row);
    void print(String printData, int print_to_column, int print_to_row);
    void clear();
    void clear(int row);
    void backlight(bool state);

  protected:
    uint8_t lcdAddress = 0x3F;
    int lcdColumns = 20;
    int lcdRows = 4;
    LiquidCrystal_I2C* lcdScreen;

  private:
    void setCursor(int column, int row);
    
};