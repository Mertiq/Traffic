using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Canvas gameOverCanvas;
    public Canvas gameCanvas;

    public static bool gameOver = false;

    private void Start()
    {
        gameOver = false;
    }

    void Update()
    {
        if(gameOver)
        {
            gameCanvas.gameObject.SetActive(false);
            gameOverCanvas.gameObject.SetActive(true);
        }
        else
        {
            gameCanvas.gameObject.SetActive(true);
            gameOverCanvas.gameObject.SetActive(false);
        }
    }



    
}
