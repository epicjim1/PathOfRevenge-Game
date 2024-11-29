using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float stopingDistance;
    public float retreatDistance;
    public float speed;
    public float playerLock;
    public bool isActive;
/*
    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public AudioSource fire;
    public GameObject bullet;*/
    Transform player;
    //public Transform firePoint;

    void Start()
    {
        isActive = true;
        //timeBetweenShots = startTimeBetweenShots;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < playerLock)
        {
            move2();
            //shoot();
            look();
        }
    }

    private void FixedUpdate()
    {
        //move();
    }

    public void look()
    {
       /* Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
       */
       if (isActive == true)
        {
            Vector3 dir = player.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        
    }

    void move()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void move2()
    {
        if (Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }

    /*public void shoot()
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
    }*/
}
