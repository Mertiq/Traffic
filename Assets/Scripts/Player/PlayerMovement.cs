using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 15f;
    public static float side_speed = 40f;
    public static float right_border_x = 15f;
    public static float left_border_x = -15f;

    GameObject waypoint;

    public static bool move_left = false;
    public static bool move_right = false;
    public static bool speed_up = false;
    public static bool speed_down = false;

    private void Start()
    {
        speed = 15f; side_speed = 40f; right_border_x = 15f; left_border_x = -15f; move_left = false; move_right = false;
        waypoint = GetComponentInParent<Car>().waypoint;
    }

    void FixedUpdate()
    {
        StayInside();
        if(!GameOver.gameOver)
            MoveForward();

        if (speed_up)
            SpeedUp();

        if (speed_down)
            SpeedDown();

        if (move_left)
        {
            if (transform.position.x > left_border_x)
            {
                Vector3 newPos = new Vector3(left_border_x, 0, 0);
                transform.Translate(newPos.normalized * Time.deltaTime * side_speed, Space.World);
            }
        }

        if (move_right)
        {
            if (transform.position.x < right_border_x)
            {
                Vector3 newPos = new Vector3(right_border_x, 0, 0);
                transform.Translate(newPos.normalized * Time.deltaTime * side_speed, Space.World);
            }
        }
    }

    void StayInside()
    {
        if (transform.position.x < left_border_x)
        {
            Vector3 temp = new Vector3(left_border_x, transform.position.y, transform.position.z);
            if (temp.x >= left_border_x)
                transform.position = temp;
        }
        if (transform.position.x > right_border_x)
        {
            Vector3 temp = new Vector3(right_border_x, transform.position.y, transform.position.z);
            if (temp.x <= right_border_x)
                transform.position = temp;
        }
    }

    public static void MoveRight()
    {
        move_right = true;
    }
    public static void MoveLeft()
    {
        move_left = true;
    }

    public void MoveForward()
    {
        Vector3 dir = new Vector3(0, 0, waypoint.transform.position.z - transform.position.z);
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }

    public static void SpeedDown()
    {
        if(speed >= 1)
        {
            speed -= 15* Time.deltaTime;
        }
    }

    public static void SpeedUp()
    {
        speed += 5*Time.deltaTime;
    }
}
