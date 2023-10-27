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
    private int playerCode; // ÇÃ·¹ÀÌ¾î ¼±ÅÃÇßÀ» ¶§ ³Ñ¾î¿À´Â Character ÄÚµå

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
            //½Ã°£ 
            time += Time.deltaTime;
            TimeText.text = $"Score :{(int)time}";
        }
        else
        {
            //Àç½ÃÀÛ
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
            PlayerPrefs.SetInt($"Player{playerCode}", (int)BestScore); // ÇÃ·¹ÀÌ¾î ÄÚµå¿¡ µû¸¥ Á¡¼ö ÀúÀå
        }

        // RecordText.text = $"ÃÖ°í±â·Ï :{(int)BestScore}";
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
                { // playerScore ºñ±³
                    temp = playerScore[i];
                    playerScore[i] = playerScore[j];
                    playerScore[j] = temp;
                }
            }
        }

        string bestText = "ÃÖ°í±â·Ï\n";
        for (int i = 0; i < playerScore.Count; i++)
        {
            bestText += $"{i}µî {playerScore[i]}\n";
        }

        RecordText.text = bestText;
    }
}
