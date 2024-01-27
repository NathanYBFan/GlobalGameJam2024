using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    private GameObject connectionPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        GameManager._Instance.PlayerRootObject.transform.position = connectionPoint.transform.position;
    }
}
