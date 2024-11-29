using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public int health;
    //public GameObject Health;
    playerUI playerUI;

    public GameObject script;
    public GameObject myCamera;
    public AudioSource death;
    public GameObject Animation;
    public GameObject explode;

    void Start()
    {
        //playerHealth.health = 100;
        playerUI = GetComponent<playerUI>();
    }

    void Update()
    {
        //Health.GetComponent<Text>().text = Convert.ToString(health);
        setStats();
    }

    public void hit(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(die());
        }
    }

    void setStats()
    {
        playerUI.healthAmount.text = health.ToString();
    }

    IEnumerator die()
    {
        myCamera.GetComponent<follow>().enabled = false;
        Destroy(gameObject.GetComponent<SpriteRenderer>());
        Destroy(gameObject.GetComponent<PolygonCollider2D>());
        Destroy(gameObject.GetComponent<TrailRenderer>());
        script.GetComponent<Shoot>().enabled = false;
        script.GetComponent<movement>().enabled = false;
        death.Play();
        explosion();
        //Destroy(gameObject, 3f);

        yield return new WaitForSeconds(3);
        //DEATH TRANSITION HERE
        var lvl2 = Animation.GetComponent<levelChanger>();
        lvl2.fadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    void explosion()
    {
        explode = Instantiate(explode, gameObject.transform.position, Quaternion.identity);
        explode.GetComponent<ParticleSystem>().Play();
        Destroy(explode, .8f);
    }
}
