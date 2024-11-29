using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedPowerup : MonoBehaviour
{
    public GameObject player;
    public AudioSource powerup;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            //myPlayer active = collision.GetComponent<myPlayer>();
            myPlayer.speedOn = true;

            powerup.Play();

            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(gameObject, 3f);
        }
    }

    void Update()
    {
        
    }
}
