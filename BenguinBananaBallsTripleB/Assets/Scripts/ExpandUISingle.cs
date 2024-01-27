using UnityEngine;

public class ExpandUISingle : MonoBehaviour
{
    public float expansionRate = 0.1f;
    public float maxSize = 300f;

    public void ExpandUI()
    {
        Vector3 newSize = transform.localScale + Vector3.one * expansionRate;

        // Check against the maximum Size and holds it
        if (newSize.x <= maxSize && newSize.y <= maxSize && newSize.z <= maxSize)
        {
            transform.localScale = newSize;
        }
    }
}