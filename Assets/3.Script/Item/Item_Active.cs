using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Active : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigid;
    // 플레이어 속도 불러오기 
    private Player_Move player_move;
    private Animator animator;


    public  bool isGodmode;
    public bool isGiant;
    private float originalPlayer;

    private void Start()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        player_move = GetComponent < Player_Move>();
        animator = GetComponent<Animator>();
        originalPlayer = transform.localScale.x;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            isGodmode = other.gameObject.name.Contains("Godmode");
            isGiant = other.gameObject.name.Contains("Giant");

            if (isGodmode)
            {

                Debug.Log("충돌");

                //Setbool로 walk가 true;
                //animator.SetBool("walk", true);

                //플레이어 속도 증가 
                player_move.Speed = 40f;

                //rigid.isKinematic = true;
                //capsuleCollider.enabled = false;

   
                StartCoroutine(OffiaGodmode(2f));
                Debug.Log("복귀");

            }
            if (isGiant)
            {

                transform.localScale = new Vector3(originalPlayer * 3f, originalPlayer * 3f, originalPlayer * 3f);

                StartCoroutine(OffisGiant(4f));

                Debug.Log("복귀");

            }

            // 아이템 비활성화
            other.gameObject.SetActive(false);
        }

    }

    private IEnumerator OffiaGodmode(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        //Setbool로  walk가 false;
        //animator.SetBool("walk", false);
      
        rigid.isKinematic = false;
       
        //스피드 복구 
        player_move.Speed = 7f;
       
        isGodmode = false;
    }

    private IEnumerator OffisGiant(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        rigid.isKinematic = false;

        //스케일 복구
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);
        //is Giant, isGodmode false;
        isGiant = false;
       
    }
    //2023-10-26 박준영 

}