using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float start = -30;

    public Text scoreText;
    public Text distanceBonusText;
    public Text timeBonusText;
    public Text totalScoreText;
    public Text highscoreText;
    public static GameObject player;

    bool isHighScore = false;
    public bool resetHighscore = false;

    float distanceBonus;
    float timeBonus;
    public float totalScore;
    public float highscore;

    void LateUpdate()
    {
        if (resetHighscore)
        {
            highscoreReset();   
        }

        highscore = PlayerPrefs.GetFloat("highscore");

        if (totalScore > highscore)
            isHighScore = true;

        distanceBonus = (float)Math.Round((player.transform.position.z - start) / 10);

        scoreText.text = "Score: " + Math.Round((player.transform.position.z - start) / 10).ToString();

        if (!GameOver.gameOver)
        {
            if (GameOver.gameWin)
            {
                timeBonus = 121 - (float) Math.Round(TimeManagement.currentTime, 1);
                totalScore = distanceBonus * timeBonus;

                distanceBonusText.text = "Distance Bonus: " + distanceBonus.ToString();
                timeBonusText.text = "Time Bonus: " + timeBonus.ToString();

                if (isHighScore)
                {
                    PlayerPrefs.SetFloat("highscore", totalScore);
                    totalScoreText.text = "High Score " + totalScore.ToString();
                    isHighScore = false;
                }
                else
                {
                    totalScoreText.text = "Total Score " + totalScore.ToString();
                }
            }
            else
            {
                timeBonus = (float)Math.Round(TimeManagement.currentTime, 1);
                totalScore = distanceBonus * timeBonus;

                distanceBonusText.text = "Distance Bonus: " + distanceBonus.ToString();
                timeBonusText.text = "Time Bonus: " + timeBonus.ToString();

                if (isHighScore)
                {
                    PlayerPrefs.SetFloat("highscore", totalScore);
                    totalScoreText.text = "High Score " + totalScore.ToString();
                    isHighScore = false;
                }
                else
                {
                    totalScoreText.text = "Total Score " + totalScore.ToString();
                }
            }
            highscoreText.text = "Highscore " + PlayerPrefs.GetFloat("highscore");
        }
    }

    void highscoreReset()
    {
        PlayerPrefs.DeleteKey("highscore");
    }
}
