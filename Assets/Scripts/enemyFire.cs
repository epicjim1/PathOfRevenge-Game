using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFire : MonoBehaviour
{
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public AudioSource fire;
    public GameObject bullet;
    public Transform firePoint;

    void Start()
    {
        
    }

    void Update()
    {
        shoot();
    }

    public void shoot()
    {
        if (timeBetweenShots <= 0)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            fire.Play();
            timeBetweenShots = startTimeBetweenShots;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }
    }
}
