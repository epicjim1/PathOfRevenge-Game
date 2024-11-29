using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnKey : MonoBehaviour
{
    public GameObject key;
    public GameObject enemy;
    //int count;

    void Start()
    {
        //count = 0;
    }

    void Update()
    {
        /*if (enemy == null)
        {
            count++;
            if (count == 1)
            {
                Instantiate(key, enemy.transform.position, Quaternion.identity);
            }
        }
        */
    }

    public void SpawnKey()
    {
        Instantiate(key, enemy.transform.position, Quaternion.identity);
    }
}
