using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Move : MonoBehaviour
{
    private float position_X;
    private void FixedUpdate()
    {
        position_X -= 0.1f;
        transform.position = new Vector3(position_X, transform.position.y, 0f);
    }
}
