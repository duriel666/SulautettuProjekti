#include "dht.h"
#define dht_apin A0

dht DHT;

const int VccPin2 = A0;  // Käyttöjännite
const int xPin   = A1;   // x-kanavan mittaus
const int yPin   = A2;   // y-kanava
const int zPin   = A3;   // z-kanava
const int GNDPin2 = A4;  // laitteen maa-napa

unsigned long aika = 0;

int x = 0;
int y = 0;
int z = 0;
float ax = 0.0;
float ay = 0.0;
float az = 0.0;
int SisaanTunniste = 0;
int indeksi = 0;
int redpin = 4;
int bluepin = 3;
int greenpin = 2;

char val = '3';
void setup()
{
    Serial.begin (9600);
    pinMode(VccPin2, OUTPUT);
    pinMode(GNDPin2, OUTPUT);
    digitalWrite(VccPin2, HIGH);
    delayMicroseconds(2); 
    digitalWrite(GNDPin2, LOW); 
    delayMicroseconds(2);
analogWrite(4, 0);
    analogWrite(3, 0);
    analogWrite(2, 128);
    while(Serial.available() != 0){} 
}

void loop()
{
  if (Serial.available() > 0)
    {/*
        char ReaderFromNode; // Store current character
        ReaderFromNode = (char) Serial.read();
        convertToState(ReaderFromNode); // Convert character to state  */      
        val = Serial.read();
        //val = incomingByte.toInt();

        if(val == '3')
        {
            analogWrite(4, 0);
            analogWrite(3, 0);
            analogWrite(2, 128);
            delay (1);
        }
        if(val == '2')
        {
            analogWrite(4, 0);
            analogWrite(3, 128);
            analogWrite(2, 0);
            delay (1);
        }
        if(val == '1')
        {
            analogWrite(4, 128);
            analogWrite(3, 128);
            analogWrite(2, 0);
            delay (1);
        }
        if(val == '0')
        {
            analogWrite(4, 128);
            analogWrite(3, 0);
            analogWrite(2, 0);
            delay (1);
        }
    }
    if(SisaanTunniste == 0)
    {
        delay(1);
        SisaanTunniste = 1;
    }

    x = 0;
    y = 0;
    z = 0;

    for(indeksi = 0; indeksi < 20; indeksi++)
    {
        x = x + analogRead(xPin);
        y = y + analogRead(yPin);
        z = z + analogRead(zPin);
    }

    aika = millis();
 
    x = x / 20;
    y = y / 20;
    z = z / 20;

    ax = 0.1411 * x - 45.718;
    ay = 0.1411 * y - 37.528;
    az = 0.1411 * z - 45.998;

    DHT.read11(dht_apin);
    
    //char xx[10];
    //dtostrf(ax,2,3,xx);
    
    //Serial.print("1234");
    //Serial.print(",");
    Serial.print(ax);
    Serial.print("a");
    /*Serial.print(ay);
    Serial.print(",");
    Serial.print(az);
    Serial.print(",");
    Serial.print(DHT.humidity);
    Serial.print(",");
    Serial.println(DHT.temperature);*/

    //delay(1000);
}
