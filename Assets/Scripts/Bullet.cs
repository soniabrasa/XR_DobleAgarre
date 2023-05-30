using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // AddForce magnitude
    float force;

    // Time To Life
    float ttl;


    void Start()
    {
        // Para ver despacio
        force = 100f;
    }


    void Update()
    {
    }

    public void Shot()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        // public void AddForce(Vector3 force, ForceMode mode = ForceMode.Force);
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }
}
