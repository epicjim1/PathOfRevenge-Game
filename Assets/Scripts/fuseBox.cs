using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuseBox : MonoBehaviour
{
    public AudioSource electric;
    public GameObject chain;

    public float x;
    public float y;
    public float z;
    float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void broken()
    {
        electric.Play();
        if (distance < 9f)
        {
            Vector3 oldPos = chain.transform.position;
            chain.transform.Translate(x * Time.deltaTime, y * Time.deltaTime, z * Time.deltaTime);
            distance += Vector3.Distance(oldPos, chain.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
