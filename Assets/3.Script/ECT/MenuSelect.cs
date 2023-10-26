using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSelect : MonoBehaviour
{
    public void OnClickButton(int i)
    {
        PlayerPrefs.SetInt("Character", i);
    }
}
