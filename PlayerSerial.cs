using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSerial : MonoBehaviour
{
    SerialPort stream = new SerialPort("COM5", 9600);
    public GameObject character;
    public int health = 3;
    void Start()
    {
        stream.Open();
    }
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
                print("Blue");
            }
            if (health == 2)
            {
                print("Green");
            }
            if (health == 1)
            {
                print("Yellow");
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
        this.health -= 1;
        yield return new WaitForSeconds(2f);
        finishedCoroutine = true;
        print("timeDamage done");
    }
    void Update()
    {
        if (stream == null)
        {
            return;
        }
        string value = stream.ReadLine();
        string[] vec3 = value.Split(',');
        if (vec3[0] != "" && gameObject.tag == "Player")
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -0.95f, 0.95f), transform.position.y, transform.position.z);
            float xaxel = float.Parse(vec3[0], CultureInfo.InvariantCulture.NumberFormat);
            if (xaxel <= 0)
            {
                transform.position += Vector3.right * -(xaxel / 5) * Time.deltaTime;
            }
            if (xaxel >= 0)
            {
                transform.position += Vector3.left * (xaxel / 5) * Time.deltaTime;
            }
        }
        if (health == 3)
        {
            if (stream.IsOpen == false)
            {
                stream.Open();
                stream.Write("3");
            }
            stream.Write("3");
        }
        if (health == 2)
        {
            if (stream.IsOpen == false)
            {
                stream.Open();
                stream.Write("2");
            }
            stream.Write("2");
        }
        if (health == 1)
        {
            if (stream.IsOpen == false)
            {
                stream.Open();
                stream.Write("1");
            }
            stream.Write("1");
        }
        if (health <= 0)
        {
            if (stream.IsOpen == false)
            {
                stream.Open();
                stream.Write("0");
            }
            stream.Write("0");
        }
        if (vec3[1] != "" && gameObject.tag == "aurinko")
        {
            float sunaxel = float.Parse(vec3[1], CultureInfo.InvariantCulture.NumberFormat);
            if (sunaxel <= 0)
            {
                transform.Rotate(0.0f, 0.0f, 0.0f, Space.World);
            }
            /*if(sunaxel >= 20 && sunaxel <= 30)
            {
                transform.Rotate(45.0f, 0.0f, 0.0f, Space.World);
            }*/
            if (sunaxel >= 0)
            {
                transform.Rotate(90.0f, 0.0f, 0.0f, Space.World);
            }
        }
    }
}
