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
    public static GameObject player;

    bool isHighScore = false;

    void LateUpdate()
    {
        scoreText.text = "Score: " + Math.Round((player.transform.position.z - start) / 10).ToString();
        if (!GameOver.gameOver)
        {
            if (GameOver.gameWin)
            {
                double distanceBonus = Math.Round((player.transform.position.z - start) / 10);
                double timeBonus = 121 - Math.Round(TimeManagement.currentTime, 1);
                double totalScore = distanceBonus * timeBonus;
                distanceBonusText.text = "Distance Bonus: " + distanceBonus.ToString();
                timeBonusText.text = "Time Bonus: " + timeBonus.ToString();
                if (isHighScore)
                {
                    totalScoreText.text = "High Score " + totalScore.ToString();
                }
                else
                {
                    totalScoreText.text = "Total Score " + totalScore.ToString();
                }
            }
            else
            {
                double distanceBonus = Math.Round((player.transform.position.z - start) / 10);
                double timeBonus = Math.Round(TimeManagement.currentTime, 1);
                double totalScore = distanceBonus * timeBonus;
                distanceBonusText.text = "Distance Bonus: " + distanceBonus.ToString();
                timeBonusText.text = "Time Bonus: " + timeBonus.ToString();
                if (isHighScore)
                {
                    totalScoreText.text = "High Score " + totalScore.ToString();
                }
                else
                {
                    totalScoreText.text = "Total Score " + totalScore.ToString();
                }
            }
            
        }
    }
}
