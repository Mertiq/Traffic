using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public static GameObject player_prefab;

    void LateUpdate()
    {
        Vector3 pos = new Vector3(0f, player_prefab.transform.position.y, player_prefab.transform.position.z); 
        transform.position = pos + new Vector3(0, 49f, -45f);
    }
}
