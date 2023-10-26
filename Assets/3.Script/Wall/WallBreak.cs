using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    private GameObject player;
    private float boundForce = 100f;

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
        Vector3 wallPosition = new Vector3(transform.position.x, transform.position.y, transform.position.x);
        ContactPoint cp = collision.GetContact(0); // 충돌 시 충돌되는 접점의 정보 반환
        Vector3 dir = new Vector3(0, wallPosition.x - cp.point.x, wallPosition.x - cp.point.x); // x축 방향으로 플레이어 진행중이라 x축 충돌 접점 정보 방향으로
        gameObject.transform.GetComponent<Rigidbody>().AddForce((dir).normalized * boundForce);
    } // 23. 10. 26 이재윤
    //2023-10-25 박준영 
}