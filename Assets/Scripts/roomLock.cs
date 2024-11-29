using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roomLock : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject enemy;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wall1.SetActive(false);
        wall2.SetActive(false);
    }

    void Update()
    {
        if (enemy == null)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
        }
    }
}
