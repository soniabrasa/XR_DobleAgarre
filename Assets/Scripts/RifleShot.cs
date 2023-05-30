using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shotPoint;
    public AudioClip shotClip;

    int totalBullets;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        totalBullets = 0;
    }


    void Update()
    {
    }

    public void Shot()
    {
        Vector3 position = shotPoint.position;
        Quaternion rotation = shotPoint.rotation;

        GameObject bulletGo = Instantiate(bulletPrefab, position, rotation);
        totalBullets++;
        bulletGo.name = $"Bullet_{totalBullets}";

        audioSource.PlayOneShot(shotClip);
    }
}
