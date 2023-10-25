using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBreak : MonoBehaviour
{
    // [JaeYun] WallBreak: 벽이 무적상태의 플레이어와 닿았을 때 사용
    private void OnCollisionEnter(Collision collision)
    {
        //플레이어 tag를 가진 오브젝트가 부딪혔을 때 && is자이언트를 먹었을 때 라는 조건을 추가 해주세요... mh
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;// is키네마틱 체크를 해제한다... mh
        }
    }
}
