using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameoverText;
    [SerializeField] private Text TimeText;
    [SerializeField] private Text[] RecordText;

    private float time = 0;
    private bool isGameover = false;
    private int playerCode;
    private bool First_Start = false;
    private void Start()
    {
        playerCode = PlayerPrefs.GetInt("Character");

    }

    private void Update()
    {
        ScoreAndGameover();
    }



    private void ScoreAndGameover()
    {
        if (!isGameover)
        {

            time += Time.deltaTime;
            TimeText.text = $"Score : {(int)time}";
            PlayerPrefs.SetInt("Tmep", (int)time);//템프에 저장
        }
        else
        {


            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Intro");
            }
        }
    }
    public void Best_Score()
    {

        if (PlayerPrefs.GetInt("Tmep") > PlayerPrefs.GetInt("One"))
        {
            if(PlayerPrefs.GetInt("One")==0)
            {
                PlayerPrefs.SetInt("One", PlayerPrefs.GetInt("Tmep"));                
                return;
            }
            else
            {
                if(PlayerPrefs.GetInt("Two") > PlayerPrefs.GetInt("Three") && PlayerPrefs.GetInt("Three")!=0)
                {
                    PlayerPrefs.SetInt("Three", PlayerPrefs.GetInt("Two"));
                }
                PlayerPrefs.SetInt("Two", PlayerPrefs.GetInt("One"));
                PlayerPrefs.SetInt("One", PlayerPrefs.GetInt("Tmep"));
                
                return;
            }
           
        }else if (PlayerPrefs.GetInt("Tmep") > PlayerPrefs.GetInt("Two"))
        {
            PlayerPrefs.SetInt("Three", PlayerPrefs.GetInt("Two"));
            PlayerPrefs.SetInt("Two", PlayerPrefs.GetInt("Tmep"));
            
            return;
        }
        else if (PlayerPrefs.GetInt("Tmep") > PlayerPrefs.GetInt("Three"))
        {
            PlayerPrefs.SetInt("Three", PlayerPrefs.GetInt("Tmep"));
        }



    }

    public void EndGame()
    {
        isGameover = true;
        GameoverText.SetActive(true);

        int temp = 0;
        int playerCount = 0;
        int[] playerScore = { 0 };


        Best_Score();


        RecordText[0].text = $"1. {PlayerPrefs.GetInt("One")}";
        RecordText[1].text = $"2. {PlayerPrefs.GetInt("Two")}";
        RecordText[2].text = $"3. {PlayerPrefs.GetInt("Three")}";



    }
}
