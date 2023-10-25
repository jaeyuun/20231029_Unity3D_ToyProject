using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // [JaeYun] WallBreak: 벽이 무적상태의 플레이어와 닿았을 때 사용
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && player.transform.GetComponent<Player_Itme>().isGiant)//추가 해주세요 조건 플레이어가 자이언트 아이템을 먹었을 때 is키네틱을 false로 바꿔주세요
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}