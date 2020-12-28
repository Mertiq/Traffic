using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Line : MonoBehaviour
{
    [Header("variables")]
    public int line_quantity = 333;
    public Vector3 line_left_pos = new Vector3(-8f, .5f, -90f);
    public Vector3 line_right_pos = new Vector3(8f, .5f, -90f);

    [Header("game objects")]
    public GameObject line_prefab;
    public GameObject line_parent;


    private void Awake()
    {
        line_quantity = 333;
        line_left_pos = new Vector3(-8f, .5f, -90f);
        line_right_pos = new Vector3(8f, .5f, -90f);
        Load();
    }

    void Load()
    {
        for (int i = 0; i < line_quantity; i++)
        {
            Vector3 offset = new Vector3(0, 0, 30 * i);
            GameObject line_left = (GameObject)Instantiate(line_prefab, line_left_pos + offset, Quaternion.identity);
            GameObject line_right = (GameObject)Instantiate(line_prefab, line_right_pos + offset, Quaternion.identity);
            line_left.transform.SetParent(line_parent.transform);
            line_right.transform.SetParent(line_parent.transform);
        }
    }
}
