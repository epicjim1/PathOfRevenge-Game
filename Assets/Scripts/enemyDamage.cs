using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyDamage : MonoBehaviour
{
    public GameObject self;
    public Material[] mat;
    public AudioSource explosion;
    public ParticleSystem explode;
    public GameObject eyes;
    GameObject bullet;
    public GameObject Key;

    public bool key;
    public int health;
    public GameObject script;
    
    SpriteRenderer color;

    private void Start()
    {
        eyes.SetActive(true);
        //health = 100;
        color = gameObject.GetComponent<SpriteRenderer>();
        color.sharedMaterial = mat[0];
    }
    
    public void takeDamage(int damage)
    {
        health -= damage;
        color.sharedMaterial = mat[1];
        if (health <= 0)
        {
            die();
        }
    }

    void die()
    {
        explode.Play();
        explosion.Play();
        
        //spawnRandom(enemys);
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        eyes.SetActive(false);
        script.GetComponent<enemyMove>().enabled = false;
        if (key == true)
        {
            Spawnkey();
        }

        Destroy(gameObject, 1f);
    }

    void Spawnkey()
    {
        Instantiate(Key, self.transform.localPosition, Quaternion.identity);
    }

    void spawnRandom(int enemyNum)
    {
        health = 100;
        Vector3 pos = new Vector3();
        Instantiate(gameObject, pos, Quaternion.identity);
    }
}
