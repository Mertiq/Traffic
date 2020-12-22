using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    readonly float rightOffset = 15f;
    readonly float leftOffset = -15f;
    public float sideSpeed = 25f;

    public Transform waypoint;

   

    void Update()
    {
        StayInside();
        
        MoveForward();

        MoveLeftRight();

        if (Input.GetKey(KeyCode.DownArrow))
            SpeedDown();
        else
            SpeedUp();
       
    }

    void StayInside()
    {
        if (transform.position.x < leftOffset)
            transform.position = new Vector3(leftOffset, transform.position.y, transform.position.z);
        if (transform.position.x > rightOffset)
            transform.position = new Vector3(rightOffset, transform.position.y, transform.position.z);
    }

    void MoveLeftRight()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > leftOffset)
            {
                Vector3 newPos = new Vector3(leftOffset, 0, 0);
                transform.Translate(newPos.normalized * Time.deltaTime * sideSpeed, Space.World);
            }   
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < rightOffset)
            {
                Vector3 newPos = new Vector3(rightOffset, 0, 0);
                transform.Translate(newPos.normalized * Time.deltaTime * sideSpeed, Space.World);
            }
        }
    }

    void MoveForward()
    {
        if(speed > 4)
        {
            Vector3 dir = new Vector3(0,0, waypoint.position.z - transform.position.z);
            transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
        }
    }
    void SpeedDown()
    {
        if(speed > 4.1)
            speed -= 0.03f;
    }

    void SpeedUp()
    {
        speed += 0.03f;
    }
}
