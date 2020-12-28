using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_Player : MonoBehaviour
{
    [Header("variables")]
    public Vector3 player_pos = new Vector3(0, 1.1f, -30f);

    [Header("game objects")]
    public GameObject player_prefab;
    public GameObject waypoint;

    private void Awake()
    {
        player_pos = new Vector3(0, 1.1f, -30f);
        Load();
    }

    void Load()
    {
        player_prefab.GetComponent<Car>().waypoint = waypoint;
        GameObject player = Instantiate(player_prefab, player_pos, player_prefab.transform.rotation);
        FollowPlayer.player_prefab = player;
        SliderControl.player_prefab = player;
    }

}
