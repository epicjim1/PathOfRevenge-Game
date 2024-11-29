using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject impact;
    public GameObject bulletEnd;
    public AudioSource hit;

    public float speed = 20f;
    public int damage = 20;
    public Rigidbody2D rb;
    
    void Start()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        playerHealth player = hitInfo.GetComponent<playerHealth>();
        enemyDamage enemy = hitInfo.GetComponent<enemyDamage>();
        fuseBox box = hitInfo.GetComponent<fuseBox>();
        boss boss = hitInfo.GetComponent<boss>();

        impactPlay();

        if (box != null)
        {
            box.broken();
            destroy();
        }
        else if (player != null)
        {
            player.hit(damage);
            destroy();
        }
        else if (enemy != null)
        {
            enemy.takeDamage(damage);
            destroy();
        }
        else if (boss != null)
        {
            boss.hit(damage);
        }
        else if(hitInfo.gameObject.tag == "Object" || hitInfo.gameObject.tag == "Enemy")
        {
            destroy();
        }
    }

    void destroy()
    {
        hit.Play();
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(gameObject, .3f);
    }

    void impactPlay()
    {
        impact = Instantiate(impact, bulletEnd.transform.position, Quaternion.identity);
        impact.GetComponent<ParticleSystem>().Play();
        Destroy(impact, .8f);
    }
    
    void Update()
    {
        
    }
}
