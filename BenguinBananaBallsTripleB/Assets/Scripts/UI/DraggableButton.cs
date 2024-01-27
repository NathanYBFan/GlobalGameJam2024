using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableButton : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }
}
