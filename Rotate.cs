using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    void Start() { }
    void Update()
    {
        transform.Rotate(Vector3.right * -15 * Time.deltaTime);
    }
}