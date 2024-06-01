using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _highscoreText;

    private static string _highscoreKey = "CurrentUserRecord";

    public void LoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void ShowPanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public static void CalculateHighscore()
    {
        if (ScoreScript.Highscore <= ScoreScript.Instance.Score)
        {
            ScoreScript.Highscore = ScoreScript.Instance.Score;
        }
        PlayerPrefs.SetInt(_highscoreKey, ScoreScript.Highscore);
    }

    public void MakePause()
    {
        Time.timeScale = 0;
    }

    public void EndPause()
    {
        Time.timeScale = 1;
    }

    public void ResetHighscore()
    {
        PlayerPrefs.SetInt(_highscoreKey, 0);
    }

    private void Awake()
    {

        ScoreScript.Highscore = PlayerPrefs.GetInt(_highscoreKey);
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            _highscoreText.text = "Рекорд: " + ScoreScript.Highscore;
        }
        
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            _scoreText.text = "Счет: " + ScoreScript.Instance.Score;
        }
        
    }

}
