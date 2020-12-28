using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed;

    GameObject waypoint;

    public bool slow_down;

    private void Start()
    {
        waypoint = GetComponentInParent<Car>().waypoint;
    }

    private void Update()
    {
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

    void SpeedDown()
    {
        speed -= 2*Time.deltaTime;
    }
    void SpeedUp()
    {
        speed += Time.deltaTime;
    }

}
