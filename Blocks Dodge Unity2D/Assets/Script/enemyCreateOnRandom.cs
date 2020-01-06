using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCreateOnRandom : MonoBehaviour
{
    public Transform[] blocks;
    int ranRange;
    public GameObject prefabs;
    float timeToSpawn = 2f;

    void Update()
    {
        if (Time.time >= timeToSpawn)
        {
            BlocksSpawn();
            timeToSpawn = Time.time + 2f;
        }
    }

    void BlocksSpawn()
    {
        ranRange = Random.Range(0, blocks.Length);
        for (int i = 0; i < blocks.Length; i++)
        {
            if (ranRange != i)
            {
                Instantiate(prefabs, blocks[i].position, Quaternion.identity);
            }
        }
    }


}
