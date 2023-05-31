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
    // Array de ParticleSystem en Rifle
    ParticleSystem[] smokingGun;

    void Start()
    {
        totalBullets = 0;

        audioSource = GetComponent<AudioSource>();

        // Particle System's array inside GameObject
        smokingGun = GetComponentsInChildren<ParticleSystem>();
    }


    // void Update() { }

    public void Shot()
    {
        // Bullet spawn
        Vector3 position = shotPoint.position;
        Quaternion rotation = shotPoint.rotation;

        GameObject bulletGo = Instantiate(bulletPrefab, position, rotation);
        totalBullets++;
        bulletGo.name = $"Bullet_{totalBullets}";

        // Bullet action
        Bullet bulletCs = bulletGo.GetComponent<Bullet>();
        bulletCs.Shot();

        // Audio Shot
        audioSource.PlayOneShot(shotClip);

        // Particle System show
        foreach (ParticleSystem smoke in smokingGun)
        {
            smoke.Play();
        }
    }
}
