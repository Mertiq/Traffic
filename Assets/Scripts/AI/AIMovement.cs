using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;
    public static float side_speed = 40f;
    public static float right_border_x = 15f;
    public static float left_border_x = -15f;

    GameObject waypoint;

    public bool slow_down;

    float count = 0;
    int rand;

    private void Start()
    {
        waypoint = GetComponentInParent<Car>().waypoint;
    }
    
    private void FixedUpdate()
    {
        count += Time.deltaTime;
        if(count < 3)
        {
            if (rand == 1)
            {
                MoveLeft();
            }
            else if (rand == 2)
            {
                MoveRight();
            }
        }
        else
        {
            rand = Random.Range(1, 10);
            count = 0;
        }
        if (slow_down && speed > 4f)
            SpeedDown();
        else if (!slow_down || speed < 3.9f)
            SpeedUp();

        MoveForward(); 
    }

    void MoveForward()
    {
        Vector3 dir = new Vector3(0, 0, waypoint.transform.position.z - transform.position.z);
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }

    void MoveLeft()
    {
        if (transform.position.x > left_border_x)
        {
            Vector3 newPos = new Vector3(left_border_x, 0, 0);
            transform.Translate(newPos.normalized * Time.deltaTime * side_speed, Space.World);
        }
    }

    void MoveRight()
    {
        if (transform.position.x < right_border_x)
        {
            Vector3 newPos = new Vector3(right_border_x, 0, 0);
            transform.Translate(newPos.normalized * Time.deltaTime * side_speed, Space.World);
        }
    }

    void SpeedDown()
    {
        speed -= 2*Time.deltaTime;
    }
    void SpeedUp()
    {
        speed += Time.deltaTime;
    }

}
