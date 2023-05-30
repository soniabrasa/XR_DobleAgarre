using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // AddForce magnitude
    float shotForce;

    // Time To Life
    float ttl;


    void Awake()
    {
        shotForce = 20f;
    }


    public void Shot()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
        rb.AddForce(transform.forward * shotForce, ForceMode.Impulse);
    }
}
