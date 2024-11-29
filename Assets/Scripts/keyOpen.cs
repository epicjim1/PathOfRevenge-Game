using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyOpen : MonoBehaviour
{
    GameObject door;
    public AudioSource key;

    public string doorName;

    void Start()
    {
        door = GameObject.FindGameObjectWithTag(doorName);
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
