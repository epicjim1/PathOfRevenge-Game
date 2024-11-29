using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretShoot : MonoBehaviour
{
    public float attackDistance;
    Transform player;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public AudioSource fire;
    public Transform firePoint;
    public GameObject bullet;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        detect();
    }

    void detect()
    {
        if (Vector2.Distance(transform.position, player.position) < attackDistance)
        {
            shoot();
        }
    }

    void shoot()
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
