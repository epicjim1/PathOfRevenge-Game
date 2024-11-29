using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colliderHit : MonoBehaviour
{
    public bool touching;
    public int damage;

    public GameObject health;

    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(Hiting());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    void Update()
    {
        /*if (touching == true)
        {
            playerHealth player = health.GetComponent<playerHealth>();

            player.hit(damage);
        }*/
    }

    IEnumerator Hiting()
    {
        playerHealth player = health.GetComponent<playerHealth>();

        //yield return new WaitForSeconds(.5f);
        player.hit(damage);
        yield return new WaitForSeconds(1);
        StopCoroutine(Hiting());
    }
}
