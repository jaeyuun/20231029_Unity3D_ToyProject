using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameoverText;
    [SerializeField] private Text TimeText;
    [SerializeField] private Text RecordText;

    private float time = 0;
    private bool isGameover = false;
    private int playerCode;

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
        }
        else
        {
            
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Intro");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        GameoverText.SetActive(true);

        float BestScore = PlayerPrefs.GetFloat("bestScore");

        if (time > BestScore)
        {
            BestScore = time;
            PlayerPrefs.SetFloat("bestScore", BestScore);
            PlayerPrefs.SetInt($"Player{playerCode}", (int)time);
        }

        int temp = 0;
        int playerCount = 0;
        int[] playerScore = { 0 };

        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey($"Player{i}")) {
                playerCount++;
                playerScore[i] = PlayerPrefs.GetInt($"Player{i}");
            }
        }
        for (int i = 0; i < playerCount; i++)
        {
            for (int j = 0; j < playerCount; j++)
            {
                if (PlayerPrefs.GetInt($"Player{i}") < PlayerPrefs.GetInt($"Player{j}"))
                { // playerScore 비교
                    temp = playerScore[i];
                    playerScore[i] = playerScore[j];
                    playerScore[j] = temp;
                }
            }
        }

        string bestText = $"최고기록\n{PlayerPrefs.GetInt($"Player{playerCode}")}";
        for (int i = 0; i < playerScore.Length; i++)
        {
            if (playerScore[i] == 0)
            {
                continue;
            }
            bestText += $"\n{i + 1}등 {playerScore[i]}\n";
        }

        RecordText.text = bestText;
    }
}
