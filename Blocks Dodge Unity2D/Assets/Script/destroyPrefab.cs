using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyPrefab : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 100;
    }

    void Update()
    {
        if (transform.position.y <= -7f)
        {
            Destroy(gameObject);
        }
    }
}
