using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControl : MonoBehaviour
{
    public Slider slider;
    public static GameObject player_prefab;

    void Update()
    {
        slider.value = player_prefab.transform.position.z + 30;
    }
}
