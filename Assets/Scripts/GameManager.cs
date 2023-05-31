using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject targetBallPrefab;

    int totalPackage;
    float radio;


    void Start()
    {
        totalPackage = 10;
        radio = 10f;

        SpawnTargetBalls();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnTargetBalls()
    {
        for (int i = 0; i <= totalPackage; i++)
        {
            float x = Random.Range(-1f, 1f) * radio;
            float y = 1f;
            float z = Random.Range(-1f, 1f) * radio;

            Vector3 position = new Vector3(x, y, z);

            Instantiate(targetBallPrefab, position, Quaternion.identity);
        }
    }
}
