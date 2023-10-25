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
    {     //플레이어가 isGiant 거나 isGodmode일 때 isKinematic false 되게 
        if (collision.gameObject.CompareTag("Player") && (player.transform.GetComponent<Player_Itme>().isGiant || player.transform.GetComponent<Player_Itme>().isGodmode))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    //2023-10-25 박준영 
}