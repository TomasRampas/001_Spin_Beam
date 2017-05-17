using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopScore : MonoBehaviour {

    public GameObject TopScoreText;
    public GameObject scoreHolder;

    Score currentScore;
    int score;
    int topScore;
    int highscore;
    Text topScoreText;

    void Awake()
    {
        currentScore = scoreHolder.GetComponent<Score>();
        topScore = PlayerPrefs.GetInt("HighScore", 0);
        topScoreText = TopScoreText.GetComponent<Text>();
        topScoreText.text = "" + topScore;
    }

	void Update ()
    {
        #region TEST INPUT

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.DeleteKey("HighScore");
        }

        #endregion
    }

    public void GameOverScoreCheck()
    {
        score = currentScore.score;
        Debug.Log("currentScore.score" + currentScore.score);
        if (score > topScore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
            topScore = PlayerPrefs.GetInt("HighScore", 0);
            topScoreText.text = "" + topScore;
        }
    }
}
