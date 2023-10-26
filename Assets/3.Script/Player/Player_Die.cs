using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    private Item_Active player;
   
    private void Awake()
    {
        TryGetComponent(out player);
    }

    private void OnCollisionEnter(Collision collision)//접촉 시 동작하는 메서드
    {
        if (collision.gameObject.CompareTag("Wall"))//Wall Tag 접촉시
        { 
            //플레이어가 isGiant가 아니거나  isGodmode가 아니면 다이 
            if (!player.isGiant && !player.isGodmode)
            {
                Debug.Log(player.isGodmode);
                Die();
                gameObject.SetActive(false);//Player 비활성화
            }
            //2023-10-25 박준영
            

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            if (!player.isGiant && !player.isGodmode)
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