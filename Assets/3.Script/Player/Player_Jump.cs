using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] private float Jump_P = 10f;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rigidbody.AddForce(1f, 0f, 0f);

        if (Input.GetButton("Jump"))
        {
            Debug.Log("มกวม");
            rigidbody.AddForce(1f, Jump_P, 0f);

        }
    }
}
