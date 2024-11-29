using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyClear2 : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject chain;
    public AudioSource open;

    public float x;
    public float y;
    public float z;
    float distance;
    int count;

    void Start()
    {
        count = 0;
    }
    
    void Update()
    {
        cleared();   
    }
    public void cleared()
    {
        if (enemies[0] == null && enemies[1] == null)
        {
            count++;
            if (distance < 7f)
            {
                Vector3 oldPos1 = chain.transform.position;
                chain.transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
                distance += Vector3.Distance(oldPos1, chain.transform.position);
            }
            if (count == 1)
            {
                open.Play();
            }
        }
    }
}
