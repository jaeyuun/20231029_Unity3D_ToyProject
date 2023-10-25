using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Itme : MonoBehaviour
{
    private CapsuleCollider capsuleCollider;
    private Rigidbody rigid;


    bool isGodmode;
    public bool isGiant;
    private float originalPlayer;

    private void Start()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();


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

                rigid.isKinematic = true;
                capsuleCollider.enabled = false;
                //rigid.AddForce(Vector3.right * 25, ForceMode.Impulse);



                StartCoroutine(RestoreColor(2f));
                Debug.Log("복귀");

            }
            if (isGiant)
            {

                transform.localScale = new Vector3(originalPlayer * 3f, originalPlayer * 3f, originalPlayer * 3f);

                StartCoroutine(RestoreColor(2f));

                Debug.Log("복귀");

            }

            // 아이템 비활성화
            other.gameObject.SetActive(false);
        }

    }

    private IEnumerator RestoreColor(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        //Setbool로  walk가 false;

        //SetTrigger idle로 true;

        rigid.isKinematic = false;
        // 다른 복원 작업 수행
        capsuleCollider.enabled = true;
        Debug.Log("돌아왔나?");
        // 다른 작업 수행 가능
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);
        isGiant = false;//자이언트 모드 false 
    }
}