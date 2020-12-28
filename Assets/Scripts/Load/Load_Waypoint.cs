using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Waypoint : MonoBehaviour
{
    [Header("variables")]
    Vector3[] waypoint_pos = { new Vector3(-15f, 0, 9500f), new Vector3(0, 0, 9500f), new Vector3(15f, 0, 9500f) };

    [Header("game objects")]
    public GameObject[] waypoint_prefabs;
    public GameObject waypoint_parent;

    void Load()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject waypoint = (GameObject)Instantiate(waypoint_prefabs[i], waypoint_pos[i], Quaternion.identity);
            waypoint.transform.SetParent(waypoint_parent.transform);
        }
    }
}
