using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 1f;
    public int minY, maxY;
    [SerializeField] private GameObject plyaer;//플레이어 값 가져오기
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;//생성주기

        if (timer >= spawnRate)
        {
            
            int randomY = Random.Range(minY, maxY);
            Instantiate(pipePrefab, new Vector3(Player_Posx(plyaer.transform.position) + 10f, randomY, 0), Quaternion.identity);
            timer = 0f;
            
        }
        
    }
    //플레이어 x위치값을 반환하는 메소드
    public float Player_Posx(Vector3 player)
    {
        return player.x;//플레이어 포지션 x값을 반환
    }
    //20231024 김민호
}