using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [Header("variables")]
    public bool is_AI;
    public bool is_player;

    [Header("game objects")]
    public GameObject waypoint;

    void Update()
    {
        if (is_AI)
        {
            if (Camera.main.transform.position.z > transform.position.z)
            {
                Destroy(gameObject);
            }
            if (waypoint.transform.position.z <= transform.position.z)
            {
                Destroy(gameObject);
            }
        }
        if (is_player)
        {
            if (waypoint.transform.position.z <= transform.position.z)
            {
                if (!GameOver.gameOver)
                {
                    GameOver.gameWin = true;
                    GameOver.gameOver = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (is_player)
        {
            if (!GameOver.gameOver)
            {
                GameOver.gameOver = true;
            }
        }
        if (is_AI)
        {
            if (collision.gameObject.CompareTag("Car"))
            {
                Destroy(gameObject);
            }
        }
    }


}
