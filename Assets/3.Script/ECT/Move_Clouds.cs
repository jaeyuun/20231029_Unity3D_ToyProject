using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Clouds : MonoBehaviour
{
    public float speed = 0.01f;
    public float posX;
    private void FixedUpdate()
    {
        posX += speed;
        transform.position = new Vector3(posX, 0, 0);
    }
}
