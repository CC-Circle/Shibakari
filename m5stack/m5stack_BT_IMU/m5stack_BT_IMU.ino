#include <M5Stack.h>
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;

float accX = 0.0F, accY = 0.0F, accZ = 0.0F;
float gyroX = 0.0F, gyroY = 0.0F, gyroZ = 0.0F;
float pitch = 0.0F, roll = 0.0F, yaw = 0.0F;
float temp = 0.0F;

void setup() {
  M5.begin();  // M5Stackの初期化
  M5.Lcd.setRotation(1);  // モニタ画面の方向を設定
  M5.Lcd.setTextSize(2);  // フォントサイズを設定

  Serial.begin(115200);  // シリアル通信を初期化

  SerialBT.begin("m5stack_shibakari"); // Bluetoothを開始し、デバイス名を設定
  Serial.println("The device started, now you can pair it with Bluetooth!");

  M5.IMU.Init();  // 慣性センサーの初期化
}

void loop() {
  // 加速度データを取得
  M5.IMU.getAccelData(&accX, &accY, &accZ);  

  // ジャイロデータを取得
  M5.IMU.getGyroData(&gyroX, &gyroY, &gyroZ);

  // 磁気センサーデータを取得
  M5.IMU.getAhrsData(&pitch, &roll, &yaw);

  // 慣性センサーの温度を取得
  M5.IMU.getTempData(&temp);

  // 画面にセンサーデータを表示
  M5.Lcd.setCursor(0, 20);
  M5.Lcd.printf("Accel: %.2f, %.2f, %.2f", accX, accY, accZ);
  M5.Lcd.setCursor(0, 40);
  M5.Lcd.printf("Gyro: %.2f, %.2f, %.2f", gyroX, gyroY, gyroZ);
  M5.Lcd.setCursor(0, 60);
  M5.Lcd.printf("Mag: %.2f, %.2f, %.2f", pitch, roll, yaw);
  M5.Lcd.setCursor(0, 80);
  M5.Lcd.printf("Temp: %.2f", temp);

  // Bluetoothでセンサーデータを送信
  SerialBT.print("Accel: ");
  SerialBT.print(accX); SerialBT.print(", ");
  SerialBT.print(accY); SerialBT.print(", ");
  SerialBT.print(accZ); SerialBT.print("\t");

  SerialBT.print("Gyro: ");
  SerialBT.print(gyroX); SerialBT.print(", ");
  SerialBT.print(gyroY); SerialBT.print(", ");
  SerialBT.print(gyroZ); SerialBT.print("\t");

  SerialBT.print("Mag: ");
  SerialBT.print(pitch); SerialBT.print(", ");
  SerialBT.print(roll); SerialBT.print(", ");
  SerialBT.print(yaw); SerialBT.print("\t");

  SerialBT.print("Temp: ");
  SerialBT.println(temp);

  delay(10);  // 100msの一時停止
}
