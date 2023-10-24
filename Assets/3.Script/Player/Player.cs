using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private SpriteRenderer spriteRenderer;

    private BoxCollider boxCollider;
    private Rigidbody rigid;
    private Material playerMaterial;
    private GameManager gameManager;
    private float originalPlayer;

    private void Start()
    {
     
        boxCollider = GetComponent<BoxCollider>();
        rigid = GetComponent<Rigidbody>();
        gameManager = GetComponent<GameManager>();
        playerMaterial = GetComponent<MeshRenderer>().material;
        //map_Move = GetComponent<Map_Move>();
        originalPlayer = transform.localScale.x;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            bool isGodmode = other.gameObject.name.Contains("Godmode");
            bool isGiant = other.gameObject.name.Contains("Giant");

            if (isGodmode)
            {

                Debug.Log("충돌");
               

                playerMaterial.color = new Color(255, 255, 0, 255);
                boxCollider.enabled = false;
                //rigid.AddForce(Vector3.right * 25, ForceMode.Impulse);



                StartCoroutine(RestoreColor(2f));
                Debug.Log("복귀");

            }
            if (isGiant)
            {

                transform.localScale = new Vector3(originalPlayer * 3f, originalPlayer * 3f, originalPlayer * 3f);

                StartCoroutine(RestoreColor(1f));
                Debug.Log("복귀");

            }

            // 아이템 비활성화
            other.gameObject.SetActive(false);
        }

    }

    private IEnumerator RestoreColor(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        // 플레이어 색상을 복원
        playerMaterial.color = new Color(255, 0, 0, 255); // 알파 값을 1로 설정하여 투명 상태 해제

        // 다른 복원 작업 수행
        boxCollider.enabled = true;
        Debug.Log("돌아왔나?");
        // 다른 작업 수행 가능
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);

    }
}
