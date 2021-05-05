using System;
using System.Collections;
using System.IO.Ports;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;
using UnityEngine;
//using WebSocketSharp;
//using WebSocketSharp.Server;

//using Sun;
using System.Text;


    
    public class Car1 : MonoBehaviour
    {
        public GameObject character;
        public int health = 3;
        private string value="0";
        void SetValue(string value){
            this.value=value;
        }
        public string getValue(){
            return this.value;
        }
        void Start()
        {
           
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
                    print("3");
                }
                if (health == 2)
                {
                    print("2");
                }
                if (health == 1)
                {
                    print("1");
                }
                if (health <= 0)
                {
                    print("0");
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
            //string value = getValue();
            string[] vec3 = getValue().Split(',');
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
            /*if (health == 3)
            {
                {
                    ws.Send("3");
                }
            }
            if (health == 2)
            {
                {
                    ws.Send("2");
                }
            }
            if (health == 1)
            {
                {
                    ws.Send("1");
                }
            }
            if (health == 0)
            {
                {
                    ws.Send("0");
                }
            }*/
        }
    }
