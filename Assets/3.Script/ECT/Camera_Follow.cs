using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform target; // 카메라가 따라다닐 대상
    public Vector3 offset; // 카메라와 대상 사이의 거리
    public float smoothSpeed = 0.125f; // 카메라의 부드러운 움직임을 위한 속도

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
