using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class Collision: MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);
    
    void Start ()
    {
        stream.Open();
    }
    public int health = 3;
    bool finishedCoroutine = true;
    void OnTriggerEnter(Collider other)
    {
        if (finishedCoroutine)
        {
            finishedCoroutine = false;
            StartCoroutine("timeDamage");
            print("Hit!");
            if (health == 3)
            {
                print("Green");
            }
            if (health == 2)
            {
                print("Yellow");
            }
            if (health == 1)
            {
                print("Blinking red");
            }
            if (health <= 0)
            {
                print("Red");
                print("You are dead!");
            }
        }
    }
    IEnumerator timeDamage()
    {
        this.health -=1;
        yield return new WaitForSeconds(2f);
        finishedCoroutine = true; 
        print("timeDamage done");
    }
    void Update()
    {
        if (health == 3)
        {
            if(stream.IsOpen==false)
                {
                    stream.Open();
                    stream.Write ("3");
                }
            stream.Write("3");
        }
        if (health == 2)
        {
            if(stream.IsOpen==false)
                {
                    stream.Open();
                    stream.Write ("2");
                }
            stream.Write("2");
        }
        if (health == 1)
        {
            if(stream.IsOpen==false)
                {
                    stream.Open();
                    stream.Write ("1");
                }
            stream.Write("1");
        }
        if (health <= 0)
        {
            if(stream.IsOpen==false)
                {
                    stream.Open();
                    stream.Write ("0");
                }
            stream.Write("0");
        }
    }  
}