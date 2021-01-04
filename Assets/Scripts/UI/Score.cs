using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float start = -30;

    public Text scoreText;
    public static GameObject player;

    void LateUpdate()
    {
        scoreText.text = Math.Round((player.transform.position.z - start) / 10).ToString();
    }
}
