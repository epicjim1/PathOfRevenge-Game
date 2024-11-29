using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyClear : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] chains;
    public AudioSource open;

    public float x1;
    public float y1;
    public float z1;
    public float x2;
    public float y2;
    public float z2;
    float distance1;
    float distance2;
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
            if (distance1 < 4f)
            {
                Vector3 oldPos1 = chains[0].transform.position;
                chains[0].transform.Translate(x1 * Time.deltaTime, y1 * Time.deltaTime, z1 * Time.deltaTime);
                distance1 += Vector3.Distance(oldPos1, chains[0].transform.position);
            }
            if (distance2 < 4f)
            {
                Vector3 oldPos2 = chains[1].transform.position;
                chains[1].transform.Translate(x2 * Time.deltaTime, y2 * Time.deltaTime, z2 * Time.deltaTime);
                distance2 += Vector3.Distance(oldPos2, chains[1].transform.position);
            }
            if(count == 1)
            {
                open.Play();
            }
        }
    }
}
