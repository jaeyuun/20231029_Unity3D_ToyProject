using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject itmePrefab;
    public float spawnRate = 1f;
    public int minY, maxY;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;//생성주기

        if (timer >= spawnRate)
        {
            int randomY = Random.Range(minY, maxY);
            Instantiate(pipePrefab, new Vector3(transform.position.x*-2f, randomY, 0), Quaternion.identity);
            Instantiate(itmePrefab, new Vector3(transform.position.x*-100f, randomY, 0), Quaternion.identity);
            timer = 0f;
            
        }
    }
}