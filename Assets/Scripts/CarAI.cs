using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{
    public Transform wayPoint;
    void Update()
    {
        if(Camera.main.transform.position.z > transform.position.z)
        {
            DestroyCar();
        }
        if (wayPoint.position.z <= transform.position.z)
        {
            DestroyCar();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Car"))
        {
            Destroy(gameObject);
        }
    }

    void DestroyCar()
    {
        Destroy(gameObject);
    }
}
