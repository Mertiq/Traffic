using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    readonly float rightOffset = 15f;
    readonly float leftOffset = -15f;
    public float sideSpeed = 40f;

    public Transform waypoint;

   

    void FixedUpdate()
    {
        StayInside();

        MoveForwardBackward();

        MoveLeftRight();

        Finish();
    }

    void Finish()
    {
        if(waypoint.position.z <= transform.position.z)
        {
            Debug.Log("FINISH");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Car"))
        {
            Debug.Log("you hit a car!");
        }
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

    void MoveForwardBackward()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            SpeedUp();
        }
        else
        {
            if(speed >= 1)
                SpeedDown();
        }
        Vector3 dir = new Vector3(0, 0, waypoint.position.z - transform.position.z);
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }

    void SpeedDown()
    {
        speed -= 5*Time.deltaTime;
    }

    void SpeedUp()
    {
        speed += 4*Time.deltaTime;
    }
}
