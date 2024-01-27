using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    public Transform Final_destination;
    //public GameObject playerg;

    public void Teleport(Vector3 position)
    {
        Debug.Log("tp works");
        transform.position = position;
        Physics.SyncTransforms();

    }
    public Transform GetDestination()
    {
        return transform;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("works");
            Teleport(Final_destination.position);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           Debug.Log("dd");
        }
    }
   
}
