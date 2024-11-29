using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class myPlayer : MonoBehaviour
{
    public static bool speedOn;
    public static int counter;

    void Start()
    {
        speedOn = false;   
    }

    void Update()
    {
        /*if (speedOn == true)
        {
            movement speedChange = gameObject.GetComponent<movement>();

            speedChange.speed = 240f;
            speedChange.maxSpeed = 6f;

            counter++;
            Debug.Log(counter);
        }*/
        /*else
        {
            movement speedChange = gameObject.GetComponent<movement>();

            speedChange.speed = 160f;
            speedChange.maxSpeed = 5f;
        }*/
    }
}
