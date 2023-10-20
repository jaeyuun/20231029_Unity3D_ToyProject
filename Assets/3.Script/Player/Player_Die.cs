using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Á×À½");
            gameObject.SetActive(false);
        }
    }
}
