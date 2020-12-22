using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        Vector3 pos = new Vector3(0f, player.transform.position.y, player.transform.position.z); 
        transform.position = pos + new Vector3(0, 49f, -45f);
    }
}
