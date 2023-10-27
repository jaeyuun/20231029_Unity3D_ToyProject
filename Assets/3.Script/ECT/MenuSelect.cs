using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    [SerializeField] private GameObject[] menu;
    public void OnClickButton(int i)
    {
        PlayerPrefs.SetInt("Character", i);//캐릭터 선택
        Debug.Log(PlayerPrefs.GetInt("Character"));
        SceneManager.LoadScene("MainGame");//메인게임으로 씬 전환
    }

    public void AnyKeyDown()
    {
        
        menu[1].SetActive(false);
        Invoke("aaa",2f);
        menu[2].SetActive(true);
    }
    private void aaa()
    {
        menu[0].SetActive(true);
    }
}
