using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Building : MonoBehaviour
{
    [Header("variables")]
    public int building_quantity = 33;
    public Vector3 building_left_pos = new Vector3(-24f, -4f, 0);
    public Vector3 building_right_pos = new Vector3(24f, -4f, 0);

    public GameObject building_prefab;
    public GameObject building_parent;

    private void Awake()
    {
        building_left_pos = new Vector3(-24f, -4f, 0);
        building_right_pos = new Vector3(24f, -4f, 0);
        Load();
    }

    public void Load()
    {
        for (int i = 0; i < building_quantity; i++)
        {
            Vector3 offset = new Vector3(0, 0, 285 * i);
            GameObject building_left = (GameObject)Instantiate(building_prefab, building_left_pos + offset, building_prefab.transform.rotation);
            GameObject building_right = (GameObject)Instantiate(building_prefab, building_right_pos + offset, building_prefab.transform.rotation);
            building_right.transform.Rotate(new Vector3(0f, -180f, 0));
            building_left.transform.SetParent(building_parent.transform);
            building_right.transform.SetParent(building_parent.transform);
        }
    }

}
