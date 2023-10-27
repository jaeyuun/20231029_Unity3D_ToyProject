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
    private int playerCode; // 플레이어 선택했을 때 넘어오는 Character 코드

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
            //시간 
            time += Time.deltaTime;
            TimeText.text = $"Score :{(int)time}";
        }
        else
        {
            //재시작
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            PlayerPrefs.SetInt($"Player{playerCode}", (int)BestScore); // 플레이어 코드에 따른 점수 저장
        }

        // RecordText.text = $"최고기록 :{(int)BestScore}";
        List<int> playerScore = new List<int>();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey($"Player{i}"))
            {
                playerScore.Add(PlayerPrefs.GetInt($"Player{playerCode}"));
            }
        }

        int temp = 0;
        string[] bestRecord = { string.Empty };
        for (int i = 0; i < playerScore.Count; i++)
        {
            for (int j = 0; j < playerScore.Count; j++)
            {
                if (playerScore[i] < playerScore[j])
                { // playerScore 비교
                    temp = playerScore[i];
                    playerScore[i] = playerScore[j];
                    playerScore[j] = temp;
                }
            }
        }

        string bestText = "최고기록\n";
        for (int i = 0; i < playerScore.Count; i++)
        {
            bestText += $"{i}등 {playerScore[i]}\n";
        }

        RecordText.text = bestText;
    }
}
