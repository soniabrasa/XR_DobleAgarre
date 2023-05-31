using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject targetBallPrefab;

    // Input Action Reference
    public InputActionReference xSpawnBalls;

    const int numBalls = 10;
    float radio;


    void Start()
    {
        radio = 10f;

        SpawnBalls();

        // Delegate InputAction TouchController LeftHand Button X
        xSpawnBalls.action.performed += OnInputActionSpawnBalls;
    }


    // Action Left Hand Controller On Touch X
    // void OnInputActionSpawnBalls(InputAction.CallbackContext ctxt)
    private void OnInputActionSpawnBalls(InputAction.CallbackContext ctxt)
    {
        Debug.Log("GameManager.OnInputActionSpawnBalls Left Hand Controller Touch X");
        SpawnBalls(numBalls);
    }

    void SpawnBalls(int n = numBalls)
    {
        for (int i = 0; i <= n; i++)
        {
            float x = Random.Range(-1f, 1f) * radio;
            float y = 1f;
            float z = Random.Range(-1f, 1f) * radio;

            Vector3 position = new Vector3(x, y, z);

            Instantiate(targetBallPrefab, position, Quaternion.identity);
        }
    }
}
