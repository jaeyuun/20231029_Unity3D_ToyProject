using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleUP_Test : MonoBehaviour
{
    float PosY;
    private void FixedUpdate()
    {
        PosY += 0.05f;
        transform.position = new Vector3(transform.position.x, PosY-5f, transform.position.z);
    }


}

