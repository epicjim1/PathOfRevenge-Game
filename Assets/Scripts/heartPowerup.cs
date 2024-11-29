using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heartPowerup : MonoBehaviour
{
    public int healthAmount;

    public AudioSource powerup;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerHealth player = collision.GetComponent<playerHealth>();

        if(player != null)
        {
            player.hit(-healthAmount);
            powerup.Play();

            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 2f);
        }
    }

    void Update()
    {
        
    }
}
