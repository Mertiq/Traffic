using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take_Input : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            PlayerMovement.SpeedUp();
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            if (PlayerMovement.speed >= 1)
                PlayerMovement.SpeedDown();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            PlayerMovement.MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            PlayerMovement.MoveLeft();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            PlayerMovement.move_right = false;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            PlayerMovement.move_left= false;
        }
    }
}
