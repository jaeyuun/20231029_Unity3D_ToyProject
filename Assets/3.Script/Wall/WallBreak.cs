using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private GameObject player;
    private float boundForce = 300f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    // [JaeYun] WallBreak: 벽이 무적상태의 플레이어와 닿았을 때 사용
    private void OnCollisionEnter(Collision collision)
    {     //플레이어가 isGiant 거나 isGodmode일 때 isKinematic false 되게 
        if (collision.gameObject.CompareTag("Player") && (player.transform.GetComponent<Item_Active>().isGiant || player.transform.GetComponent<Item_Active>().isGodmode))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            ExcecuteBounding(collision); // player collision
        }
    }

    private void ExcecuteBounding(Collision collision)
    { // Player가 무적 상태일 때 wall 바운딩
        Vector3 dir1 = new Vector3(0, 0.5f, 1);
        Vector3 dir2 = new Vector3(0, 0.5f, -1);
        int rand = Random.Range(0, 2);
        if (rand == 0)
        {
            gameObject.transform.GetComponent<Rigidbody>().AddForce((dir1).normalized * boundForce);
        }
        else
        {
            gameObject.transform.GetComponent<Rigidbody>().AddForce((dir2).normalized * boundForce);
        }
    } // 23. 10. 26 이재윤
    //2023-10-25 박준영 
}