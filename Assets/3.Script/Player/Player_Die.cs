using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    private Player_Itme player;

    private void Awake()
    {
        TryGetComponent(out player);
    }

    private void OnCollisionEnter(Collision collision)//접촉 시 동작하는 메서드
    {
        if (collision.gameObject.CompareTag("Wall"))//Wall Tag 접촉시
        {
            if (!player.isGiant)
            {
                Die();
                gameObject.SetActive(false);//Player 비활성화
            }

        }
    }
    public void Die()
    {
        if (GameManager.FindObjectOfType<GameManager>().TryGetComponent(out GameManager gm))//죽었을 때 R키를 누르시오 
        {
            gm.EndGame(); //게임 매니저로 이동 
        }
    }
    //2023/10/24 박준영 

}