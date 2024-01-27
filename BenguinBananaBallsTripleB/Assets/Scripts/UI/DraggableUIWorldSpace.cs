using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIWorldSpace : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Canvas parentCanvasOfImageToMove;
    
    [SerializeField]
    private Image imageToMove;

    private void Start()
    {
        parentCanvasOfImageToMove.worldCamera = Camera.main;
        Debug.Log(transform.position);
    }

    public void OnDrag(PointerEventData data)
    {
        Vector2 pos;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, data.position, parentCanvasOfImageToMove.worldCamera, out pos);
        pos = new Vector2(pos.x + GetComponent<Collider>().bounds.extents.x, pos.y - GetComponent<Collider>().bounds.extents.y);
        imageToMove.transform.position = parentCanvasOfImageToMove.transform.TransformPoint((Vector3) pos);
    }
}
