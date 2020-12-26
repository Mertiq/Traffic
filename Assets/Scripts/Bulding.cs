using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulding : MonoBehaviour
{
    private void Update()
    {
        if (Camera.main.transform.position.z > transform.position.z * 3)
        {
            Destroy(gameObject);
        }
    }
}
