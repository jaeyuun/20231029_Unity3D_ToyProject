using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner_Pooling : MonoBehaviour
{
    public GameObject[] pipePrefabs;
    public GameObject[] itemPrefabs;
    public float spawnRate = 2f;
    public float difficulty = 0;
    public int minY, maxY;
    [SerializeField] private GameObject player;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        difficulty += Time.deltaTime;

        Stage(difficulty);
        if (timer >= spawnRate)
        {
            int randomY = Random.Range(minY, maxY);
            GameObject pipeInstance = Instantiate(pipePrefabs[Random.Range(0, pipePrefabs.Length)]);
            pipeInstance.transform.position = new Vector3(Player_Posx(player.transform.position) + 30f, randomY, 0);

            pipeInstance.SetActive(true);

            Destroy(pipeInstance, 10f);  // 10초 후에 파괴

            // 아이템 생성
            float itemSpawnChance = Random.Range(0f, 1f);
            if (itemSpawnChance <= 0.15f) // 15% 확률로 아이템 생성
            {
                GameObject itemInstance = Instantiate(itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
                int itemY = Random.Range(minY + 2, maxY - 2); // 아이템의 높이를 파이프 사이에 위치하도록 설정
                itemInstance.transform.position = new Vector3(pipeInstance.transform.position.x, itemY, 0);
                itemInstance.SetActive(true);

                Destroy(itemInstance, 10f);  // 10초 후에 파괴
            }

            timer = 0f;
        }
    }
    private void Stage(float Stage_time)
    {
        if (Stage_time > 10)
        {
            spawnRate = 1.5f;
        }
        if (Stage_time > 20)
        {
            spawnRate = 1f;
        }
        if (Stage_time > 30)
        {
            spawnRate = 0.8f;
        }
        if (Stage_time > 50)
        {
            spawnRate = 0.5f;
        }
        if (Stage_time > 60)
        {
            spawnRate = 0.3f;
        }
    }


    public float Player_Posx(Vector3 player)
    {
        return player.x;
    }
}