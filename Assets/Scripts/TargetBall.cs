using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBall : MonoBehaviour
{
    float yToDestroy;

    void Start()
    {
        yToDestroy = -10f;
    }

    void Update()
    {
        if (transform.position.y < yToDestroy)
        {
            Destroy(gameObject);
        }
    }
}
