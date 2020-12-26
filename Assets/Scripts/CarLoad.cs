using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLoad : MonoBehaviour
{
    public int carCount;
    public GameObject[] wayPoints;
    public GameObject[] cars;
    Vector3[] waypointPos = { new Vector3(-15f, 0, 9500f), new Vector3(0, 0, 9500f), new Vector3(15f, 0, 9500f) };

    public GameObject player;
    public Transform playersWayPoint;
    Vector3 playerPos = new Vector3(0, 1.1f, -30f);

    public GameObject parentCar;
    public GameObject parentLine;
    public GameObject parentWaypoint;
    public GameObject line;

    public GameObject buildingPrefab;
    public GameObject buildingParent;

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
            GameObject xa =(GameObject) Instantiate(wayPoints[i], waypointPos[i], Quaternion.identity);
            xa.transform.SetParent(parentWaypoint.transform);
        }
        
        for (int i = 1; i < carCount; i++)
        {
            int rand = Random.Range(1, 4);
            Debug.Log("araba " + rand);
            if (rand == 1)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(-15f, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1].transform;
                GameObject xa = (GameObject) Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
                xa.transform.SetParent(parentCar.transform);
            }
            else if (rand == 2)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(0, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1].transform;
                GameObject xa = (GameObject)Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
                xa.transform.SetParent(parentCar.transform);
            }
            else if (rand == 3)
            {
                int rand2 = Random.Range(0, cars.Length);
                Vector3 pos = new Vector3(15f, 1.1f, i * distance);
                cars[rand2].GetComponent<AIMovement>().wayPoint = wayPoints[rand-1].transform;
                GameObject xa = (GameObject)Instantiate(cars[rand2], pos, cars[rand2].transform.rotation);
                xa.transform.SetParent(parentCar.transform);
            }
        }

        for (int i = 0; i < 333; i++)
        {
            Vector3 pos1 = new Vector3(-8f,.5f,-90 + (30 * i));
            Vector3 pos2 = new Vector3(8f, .5f,-90 + (30 * i));
            GameObject xa = (GameObject)Instantiate(line, pos1, Quaternion.identity);
            GameObject xb = (GameObject)Instantiate(line, pos2, Quaternion.identity);
            xa.transform.SetParent(parentLine.transform);
            xb.transform.SetParent(parentLine.transform);
        }
        /*
        for (int i = 0; i < 35; i++)
        {
            Vector3 pos1 = new Vector3(-32f, -15f, 65 + (285 * i));
            Vector3 pos2 = new Vector3(32f, -15f, 65 + (285 * i));
            GameObject xa = (GameObject)Instantiate(buildingPrefab, pos1, buildingPrefab.transform.rotation);
            GameObject xb = (GameObject)Instantiate(buildingPrefab, pos2, buildingPrefab.transform.rotation);
            xb.transform.Rotate(new Vector3(0f, -180f, 0));
            xa.transform.SetParent(buildingParent.transform);
            xb.transform.SetParent(buildingParent.transform);
        }
        */
    }

}
