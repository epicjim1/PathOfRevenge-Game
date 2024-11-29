using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShoot : MonoBehaviour
{
    public float speed;
    public int damage;

    public AudioSource hit;
    public GameObject bulletEnd;
    public GameObject impactParticle;
    public Rigidbody2D rb;
    //Transform player;
    //Vector2 target;
    
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;
        //target = new Vector2(player.position.x, player.position.y);
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        enemyDamage teamMate = hitInfo.GetComponent<enemyDamage>();

        hit.Play();
        impact();

        if(player != null)
        {
            player.hit(damage);
        }
        if (teamMate != null)
        {
            teamMate.takeDamage(damage);
        }
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject, .8f);
    }

    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void impact()
    {
        impactParticle = Instantiate(impactParticle, bulletEnd.transform.position, Quaternion.identity);
        impactParticle.GetComponent<ParticleSystem>().Play();
        Destroy(impactParticle, .8f);
    }
}
