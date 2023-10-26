using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner_Pooling : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject[] itemPrefabs;
    public float spawnRate = 1f;
    public int minY, maxY;
    public int poolSize = 10;
    [SerializeField] private GameObject player;

    private float timer = 0f;
    private Queue<GameObject> pipePool;
    private List<Queue<GameObject>> itemPools;

    void Start()
    {
        pipePool = new Queue<GameObject>();
        itemPools = new List<Queue<GameObject>>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject pipeInstance = Instantiate(pipePrefab);
            pipeInstance.SetActive(false);
            pipePool.Enqueue(pipeInstance);
        }

        foreach (GameObject itemPrefab in itemPrefabs)
        {
            Queue<GameObject> itemPool = new Queue<GameObject>();
            for (int i = 0; i < poolSize; i++)
            {
                GameObject itemInstance = Instantiate(itemPrefab);
                itemInstance.SetActive(false);
                itemPool.Enqueue(itemInstance);
            }
            itemPools.Add(itemPool);
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            int randomY = Random.Range(minY, maxY);
            GameObject pipeInstance = pipePool.Dequeue();
            pipeInstance.transform.position = new Vector3(Player_Posx(player.transform.position) + 30f, randomY, 0);
            pipeInstance.transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = true;
            pipeInstance.transform.GetChild(1).GetComponent<Rigidbody>().isKinematic = true;

            pipeInstance.SetActive(true);

            pipePool.Enqueue(pipeInstance);

            // 아이템 생성
            float itemSpawnChance = Random.Range(0f, 1f);
            if (itemSpawnChance <= 0.15f) // 50% 확률로 아이템 생성
            {
                int randomItemIndex = Random.Range(0, itemPrefabs.Length);
                Queue<GameObject> itemPool = itemPools[randomItemIndex];
                GameObject itemInstance = itemPool.Dequeue();
                int itemY = Random.Range(minY + 2, maxY - 2); // 아이템의 높이를 파이프 사이에 위치하도록 설정
                itemInstance.transform.position = new Vector3(pipeInstance.transform.position.x, itemY, 0);
                itemInstance.SetActive(true);
                itemPool.Enqueue(itemInstance);
            }

            timer = 0f;
        }
    }

    public float Player_Posx(Vector3 player)
    {
        return player.x;
    }
}