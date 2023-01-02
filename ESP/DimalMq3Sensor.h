int mq3_Pin = A0;
bool isOpen = false;

void InitMq3Sensor(int mq3Pin = -1){
  if(mq3Pin > 0)
    mq3_Pin = mq3Pin;

  pinMode(mq3_Pin, INPUT);  // Set the MQ-3 pin as an input
  
  isOpen = true;
}

float Mq3SensorData(){
  if(!isOpen)
    return 0;

  int analogOutput = analogRead(mq3_Pin);
  double concentration = curve(analogOutput,a,b,c);

  return concentration / 0.789 * 100;
}