using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretRotate : MonoBehaviour
{
    public float speed;
    public Vector3 maxLeft;
    public Vector3 maxRight;

    public float maxRotation = 45f;

    void Start()
    {
        
    }

    void Update()
    {
        //Rotate();
        transform.rotation = Quaternion.Euler(0f, 0f, maxRotation * Mathf.Sin(Time.time * speed));
    }

    void Rotate()
    {
        if(transform.rotation.z < maxLeft.z)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
        else if (transform.rotation.z > maxLeft.z)
        {
            transform.Rotate(Vector3.back * speed * Time.deltaTime);
        }
        else if (transform.rotation.z < maxRight.z)
        {
            transform.Rotate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
