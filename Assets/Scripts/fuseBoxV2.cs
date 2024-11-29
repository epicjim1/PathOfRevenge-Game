using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class fuseBoxV2 : MonoBehaviour
{
    public GameObject chain;
    public AudioSource electric;
    public GameObject particle;

    int count;
    public float x;
    public float y;
    public float z;
    float distance;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        Open();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        broken();
        electric.Play();
        count += 1;
    }

    void broken()
    {
        //Instantiate(particle, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
    }

    void Open()
    {
        if (count >= 1)
        {
            if (distance < 7f)
            {
                Vector3 oldPos1 = chain.transform.position;
                chain.transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
                distance += Vector3.Distance(oldPos1, chain.transform.position);
            }
        }
    }
}
