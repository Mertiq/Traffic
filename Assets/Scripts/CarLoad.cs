using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLoad : MonoBehaviour
{
    public Transform[] wayPoints;
    public GameObject[] cars;
    Vector3[] waypointPos = { new Vector3(-15f, 0, 950f), new Vector3(0, 0, 950f), new Vector3(15f, 0, 950f) };

    public GameObject player;
    public Transform playersWayPoint;
    Vector3 playerPos = new Vector3(0, 1.1f, -30f);


    float distance = 35f;

    private void Awake()
    {
        Load();
    }

    void Load()
    {
        player.GetComponent<PlayerMovement>().waypoint = playersWayPoint;
        GameObject x = Instantiate(player, playerPos, player.transform.rotation);
        Camera.main.GetComponent<FollowPlayer>().player = x;
        for (int i = 0; i < 3; i++)
        {
            Instantiate(wayPoints[i], waypointPos[i], Quaternion.identity);
        }
        
        for (int i = 1; i < 50; i++)
        {
            int rand = Random.Range(1, 4);
            if(rand == 1)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(-15f, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1];
                Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
            }
            else if (rand == 2)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(0, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1];
                Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
            }
            else if (rand == 3)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(15f, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1];
                Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
            }
        }
    }

    private void Update()
    {
        
    }
}
