using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float Jump_P = 10f;
    public float Sleep = 10f;
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(Jump_P, 0f, 0f);

        if (Input.GetButton("Jump"))//스페이스키 입력시
        {
           
            rigidbody.AddForce(0f, Jump_P, 0f);//Jump_P만큼 힘을 준다

        }
    }
}
