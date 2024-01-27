using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Vector3 target_Offset;

    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, GameManager._Instance.PlayerRootObject.transform.position + target_Offset, 0.1f);
        transform.position = Vector3.Lerp(transform.position, GameManager._Instance.PlayerRootObject.transform.position + target_Offset, 0.1f);
    }
}
