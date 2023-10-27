using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset_Prefab : MonoBehaviour
{
    public void reset_Per()
    {
        PlayerPrefs.SetInt("One", 0);
        PlayerPrefs.SetInt("Two", 0);
        PlayerPrefs.SetInt("Three", 0);
        Debug.Log("∑©≈∑√ ±‚»≠");
    }
}
