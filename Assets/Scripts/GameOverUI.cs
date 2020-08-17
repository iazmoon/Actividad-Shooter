using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Score score;

    public Text scorelabel;
    public Text highscorelabel;

    private void OnEnable()
    {
        int currentScore = score.GetScore();
        scorelabel.text = "Score: " + score.GetScore();

        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        highscorelabel.text = "Highscore: " + highscore;
        if(currentScore > highscore)
            PlayerPrefs.SetInt("Highscore", currentScore);

    }

    public void RestartGame()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    public void CloseGame()
    {
        Application.Quit();
    }


}
