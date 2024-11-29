using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public GameObject chargeSmoke;
    public GameObject shooter;
    public GameObject enemy;
    Transform player;
    public AudioSource explosion;
    public AudioSource charging;

    public ParticleSystem implode;
    public ParticleSystem explode;

    public int chargeTime;
    public int waitTime2;
    public int healthOriginal = 240;
    public int healthLast;
    public float chargeDistance;
    public bool isIdle;
    bool isCharging;
    public float chargeSpeed;

    public Sprite newSprite;
    private Sprite matDefault;
    public SpriteRenderer sr;

    public bool instaDeath;

    void Start()
    {
        chargeSmoke.SetActive(false);
        matDefault = sr.sprite;
        isCharging = false;
        healthLast = healthOriginal;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        //Idling();
        if (Vector2.Distance(transform.position, player.position) > chargeDistance && isCharging == false)
        {
            StartCoroutine(Charge());
            isCharging = true;
        }
        
        /*if (isCharging == false && Vector2.Distance(transform.position, player.position) < chargeDistance)
        {
            enemyMovement speeding = enemy.GetComponent<enemyMovement>();
            enemyMovement looking = enemy.GetComponent<enemyMovement>();

            //StopCoroutine(Charge());
            //isIdle = false;
            looking.isActive = true;
            shooter.SetActive(true);
            speeding.speed = 3;
            speeding.retreatDistance = 3;
            speeding.stopingDistance = 5;
        }*/

        if (instaDeath == true)
        {
            if (Input.GetKeyDown("e"))
            {
                StartCoroutine(Die());
            }
        }
    }

    public void hit(int damage)
    {
        healthLast -= damage;
        checkHealth();

        if (healthLast % 60 == 0)
        {
            falseCharge();
        }
    }

    void checkHealth()
    {
        sr.sprite = newSprite;

        if (healthLast <= 0)
        {
            StopCoroutine(Charge());
            StartCoroutine(Die());
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
    }

    void ResetMaterial()
    {
        sr.sprite = matDefault;
    }

    IEnumerator Die()
    {
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        enemy.GetComponent<BoxCollider2D>().enabled = false;
        enemy.GetComponent<enemyMovement>().enabled = false;
        isCharging = true;
        explosion.Play();
        Destroy(chargeSmoke);
        Destroy(shooter);
        Implode();
        yield return new WaitForSeconds(3);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        enemy.GetComponent<SpriteRenderer>().enabled = false;
        Explode();
        Destroy(enemy, 5f);
    }

    void Idling()
    {
        if (isIdle == true)
        {
            shooter.SetActive(false);
            enemy.GetComponent<enemyMovement>().enabled = false;
        }
        else if (isIdle == false)
        {
            shooter.SetActive(true);
            enemy.GetComponent<enemyMovement>().enabled = true;
        }
    }

    IEnumerator Charge()
    {
        enemyMovement speeding = enemy.GetComponent<enemyMovement>();
        enemyMovement looking = enemy.GetComponent<enemyMovement>();

        chargeSmoke.SetActive(true);
        charging.Play();
        chargeSmoke.GetComponent<ParticleSystem>().Play();
        looking.isActive = true;
        shooter.SetActive(false);
        speeding.speed = 6;
        speeding.retreatDistance = 0;
        speeding.stopingDistance = 0;
        yield return new WaitForSeconds(chargeTime);
        charging.Stop();
        looking.isActive = false;
        speeding.speed = 0;
        speeding.retreatDistance = 0;
        speeding.stopingDistance = 0;
        yield return new WaitForSeconds(waitTime2);
        looking.isActive = true;
        shooter.SetActive(true);
        speeding.speed = 3;
        speeding.retreatDistance = 3;
        speeding.stopingDistance = 5;
        isCharging = false;
    }

    void falseCharge()
    {
        enemyMovement speeding = enemy.GetComponent<enemyMovement>();
        enemyMovement looking = enemy.GetComponent<enemyMovement>();

        StopCoroutine(Charge());
        chargeSmoke.SetActive(false);
        looking.isActive = true;
        shooter.SetActive(true);
        speeding.speed = 3;
        speeding.retreatDistance = 3;
        speeding.stopingDistance = 5;
        isCharging = false;
    }

    void Implode()
    {
        implode = Instantiate(implode, transform.position, Quaternion.identity);
        implode.GetComponent<ParticleSystem>().Play();
        Destroy(implode, 7f);
    }

    void Explode()
    {
        explode = Instantiate(explode, transform.position, Quaternion.identity);
        explode.GetComponent<ParticleSystem>().Play();
        Destroy(explode, 5f);
    }
}
