using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyOpen2 : MonoBehaviour
{
    GameObject door;
    public AudioSource key;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag("Door2");
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            key.Play();
            Destroy(door);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 5f);
        }
    }
}
