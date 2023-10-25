using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Itme : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigid;
    // 플레이어 속도 불러오기 
    private Player_Move map_Move;


    public  bool isGodmode;
    public bool isGiant;
    private float originalPlayer;

    private void Start()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        map_Move = GetComponent < Player_Move>();

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

                //플레이어 속도 증가 
                map_Move.Speed += 40.0f;

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

        //SetTrigger idle로 true;

        rigid.isKinematic = false;
       
        //스피드 복구 
        map_Move.Speed -= 40.0f;
        //스케일 복구
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);
        //is Giant, isGodmode false;
       
        isGodmode = false;
    }

    private IEnumerator OffisGiant(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        //Setbool로  walk가 false;

        //SetTrigger idle로 true;

        rigid.isKinematic = false;

        //스피드 복구 
        
        //스케일 복구
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);
        //is Giant, isGodmode false;
        isGiant = false;
       
    }
    //2023-10-25 박준영 

}