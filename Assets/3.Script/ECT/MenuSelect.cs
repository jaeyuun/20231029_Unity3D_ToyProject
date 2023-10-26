using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    
    public void OnClickButton(int i)
    {
        PlayerPrefs.SetInt("Character", i);//캐릭터 선택
        Debug.Log(PlayerPrefs.GetInt("Character"));
        SceneManager.LoadScene("MainGame");//메인게임으로 씬 전환
    }
}
