using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIWorldSpace : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Canvas parentCanvasOfImageToMove;
    [SerializeField]
    private Image imageToMove;

    public void OnDrag(PointerEventData data)
    {
        Vector2 pos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentCanvasOfImageToMove.transform as RectTransform, data.position, parentCanvasOfImageToMove.worldCamera, out pos);
        imageToMove.transform.position = parentCanvasOfImageToMove.transform.TransformPoint(pos);
    }
}
