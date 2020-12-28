using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIFrontCollision : MonoBehaviour
{
    AIMovement aIMovement;
    private void Start()
    {
        aIMovement = GetComponentInParent<AIMovement>();
    }
    private void OnTriggerStay(Collider other)
    {
        aIMovement.slow_down = true;
    }

    private void OnTriggerExit(Collider other)
    {
        aIMovement.slow_down = false;
    }
}
