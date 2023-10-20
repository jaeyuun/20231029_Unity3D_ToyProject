using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)//접촉 시 동작하는 메서드
    {
        if(collision.gameObject.CompareTag("Wall"))//Wall Tag 접촉시
        {
            Debug.Log("죽음");
            gameObject.SetActive(false);//Player 비활성화
        }
    }
}
