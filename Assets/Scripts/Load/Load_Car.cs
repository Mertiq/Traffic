using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Car : MonoBehaviour
{
    [Header("variables")]
    public int car_quantity = 500;
    public float car_between_distance = 35f;

    [Header("game objects")]
    public GameObject[] car_prefabs;
    public GameObject car_parent;
    public GameObject waypoint;

    float left_lane_pos_x = -15f;
    float mid_lane_pos_x = 0;
    float right_lane_pos_x = 15f;

    float lane_pos_y = 1.1f;

    private void Awake()
    {
        car_quantity = 500;
        car_between_distance = 35f;
        left_lane_pos_x = -15f;
        mid_lane_pos_x = 0;
        right_lane_pos_x = 15f;
        lane_pos_y = 1.1f;
        Load();
    }

    void Load()
    {
        for (int i = 1; i < car_quantity; i++)
        {
            int rand = Random.Range(1, 4); // which lane
            if (rand == 1)
            {
                int rand2 = Random.Range(0, car_prefabs.Length); // which car type
                Vector3 pos = new Vector3(left_lane_pos_x, lane_pos_y, i * car_between_distance);
                car_prefabs[rand2].GetComponent<Car>().waypoint = waypoint;

                GameObject car = (GameObject)Instantiate(car_prefabs[rand2], pos, car_prefabs[rand2].transform.rotation);
                car.transform.SetParent(car_parent.transform);
            }
            else if (rand == 2)
            {
                int rand2 = Random.Range(0, car_prefabs.Length);
                Vector3 pos = new Vector3(mid_lane_pos_x, lane_pos_y, i * car_between_distance);
                car_prefabs[rand2].GetComponent<Car>().waypoint = waypoint;

                GameObject car = (GameObject)Instantiate(car_prefabs[rand2], pos, car_prefabs[rand2].transform.rotation);
                car.transform.SetParent(car_parent.transform);
            }
            else if (rand == 3)
            {
                int rand2 = Random.Range(0, car_prefabs.Length);
                Vector3 pos = new Vector3(right_lane_pos_x, lane_pos_y, i * car_between_distance);
                car_prefabs[rand2].GetComponent<Car>().waypoint = waypoint;

                GameObject car = (GameObject)Instantiate(car_prefabs[rand2], pos, car_prefabs[rand2].transform.rotation);
                car.transform.SetParent(car_parent.transform);
            }
        }
    }

}
