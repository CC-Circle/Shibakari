using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOn : MonoBehaviour
{
    public string targetTag = "refe";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            Debug.Log("Activate OnTriggerEnter!!");
        }
    }
}
