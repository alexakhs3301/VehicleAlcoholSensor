#include "DimalLcd.h"
Lcd::Lcd(){
  
}

Lcd::Lcd(uint8_t lcd_address, int lcd_cols, int lcd_rows){
  lcdAddress = lcd_address;
  lcdColumns = lcd_cols;
  lcdRows = lcd_rows;
}

void Lcd::start(){
  if(lcdAddress == NULL)
    return;

  if(lcdColumns <= 0)
    return;

  if(lcdRows <= 0)
    return;

  lcdScreen = new LiquidCrystal_I2C(lcdAddress, lcdColumns, lcdRows);

  lcdScreen->init();
  backlight(true);
  
}

void Lcd::print(const char *printData, int print_to_column, int print_to_row){
  setCursor(print_to_column, print_to_row);
  lcdScreen->print(printData);
}

void Lcd::print(float printData, int print_to_column, int print_to_row){
  setCursor(print_to_column, print_to_row);
  lcdScreen->print(printData);
}

void Lcd::print(String printData, int print_to_column, int print_to_row){
  setCursor(print_to_column, print_to_row);
  lcdScreen->print(printData);
}

void Lcd::clear() {
  lcdScreen->clear();
}

void Lcd::clear(int row) {
  for(int i = 0; i < lcdColumns; i++){
    lcdScreen->setCursor(i, row);
    lcdScreen->print(" ");
  }
}

void Lcd::backlight(bool state) {
  if(state)
    lcdScreen->backlight();
  else
    lcdScreen->noBacklight();
}

void Lcd::setCursor(int column, int row){
  lcdScreen->setCursor(column, row);
}