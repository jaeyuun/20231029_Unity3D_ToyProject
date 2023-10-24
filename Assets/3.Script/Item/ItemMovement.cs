using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 이동 속도, 원하는 값으로 조절

    private void Update()
    {
       
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
}
