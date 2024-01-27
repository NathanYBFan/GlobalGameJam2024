using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    public Transform Final_destination;

    public void Teleport(Vector3 position)
    {
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
            
            Teleport(Final_destination.position);
        }
    }
   
}
