using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManagement : MonoBehaviour
{
    public float neededTime;
    public static float currentTime = 0;

    public Text currentTimeText;

    private void Start()
    {
        currentTime = 0;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= neededTime)
        {
            if (!GameOver.gameOver)
            {
                GameOver.gameOver = true;
            }
        }
        currentTimeText.text = "Time: " + Math.Round(currentTime, 1).ToString();
    }
}
