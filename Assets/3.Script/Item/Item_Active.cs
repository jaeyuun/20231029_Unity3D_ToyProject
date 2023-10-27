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

    [SerializeField] private AudioSource audioSource;
    public AudioClip giant;
    public AudioClip godmode;



    public bool isGodmode;
    public bool isGiant;
    private float originalPlayer;

    //walk _Sujin
    private bool iswalk;

    //particle
    [SerializeField] private GameObject speedEffect;
    [SerializeField] private GameObject GiantEffect;

    private void Start()
    {

        capsuleCollider = GetComponent<CapsuleCollider>();
        rigid = GetComponent<Rigidbody>();
        player_move = GetComponent < Player_Move>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
                iswalk = true;
                animator.SetBool("isWalk", true);

                //Particle_Sujin
                //Instantiate(speedEffect, transform.position, speedEffect.transform.rotation);
                speedEffect.SetActive(true);

                //플레이어 속도 증가 
                player_move.Speed = 30f;
                audioSource.PlayOneShot(godmode);



                //rigid.isKinematic = true;
                //capsuleCollider.enabled = false;


                StartCoroutine(OffiaGodmode(2f));
                Debug.Log("복귀");

            }
            if (isGiant)
            {
                GiantEffect.SetActive(true);

                transform.localScale = new Vector3(originalPlayer * 3f, originalPlayer * 3f, originalPlayer * 3f);
                audioSource.PlayOneShot(giant);
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
        audioSource.Stop();

        isGodmode = false;

        speedEffect.SetActive(false);
    }

    private IEnumerator OffisGiant(float delay)
    {
        yield return new WaitForSeconds(delay); // 지연

        rigid.isKinematic = false;

        //스케일 복구
        transform.localScale = new Vector3(originalPlayer, originalPlayer, originalPlayer);
        //is Giant, isGodmode false;
        isGiant = false;

        GiantEffect.SetActive(true);

    }
    //2023-10-26 박준영 

}