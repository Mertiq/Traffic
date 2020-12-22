using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 4f;

    public Transform wayPoint;

    public bool slowDown;

    private void Update()
    {
        if (slowDown && speed > 0)
            SpeedDown();
        else if (speed < 3.9f)
            SpeedUp();

        MoveForward(); 
    }

    void MoveForward()
    {
        Vector3 dir = new Vector3(0, 0, wayPoint.position.z - transform.position.z);
        transform.Translate(dir.normalized * Time.deltaTime * speed, Space.World);
    }

    void SpeedDown()
    {
        speed -= Time.deltaTime;
    }
    void SpeedUp()
    {
        speed += Time.deltaTime;
    }

}
