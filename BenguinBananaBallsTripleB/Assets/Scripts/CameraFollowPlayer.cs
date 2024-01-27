using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public Vector3 target_Offset;
    private void Start()
    {
        if (GameManager._Instance.PlayerRootObject == null) return;
        target = GameManager._Instance.PlayerRootObject.transform;
        if (target == null) return;
        target_Offset = transform.position - target.position;
    }
    void Update()
    {
        if (target != null)
            transform.position = Vector3.Lerp(transform.position, target.position + target_Offset, 0.1f);
    }
}
