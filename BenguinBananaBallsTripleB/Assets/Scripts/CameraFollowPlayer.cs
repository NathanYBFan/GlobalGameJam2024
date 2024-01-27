using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Vector3 target_Offset;
    void Update()
    {
        if (GameManager._Instance.PlayerRootObject != null)
            transform.position = Vector3.Lerp(transform.position, GameManager._Instance.PlayerRootObject.transform.position + target_Offset, 0.1f);
    }
}
