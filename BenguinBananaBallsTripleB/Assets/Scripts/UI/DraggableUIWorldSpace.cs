using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIWorldSpace : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    [SerializeField]
    private Canvas parentCanvasOfImageToMove;
    
    [SerializeField]
    private Image imageToMove;

    private Vector3 originalMouseClickPos;


    private void Start()
    {
        parentCanvasOfImageToMove.worldCamera = Camera.main;
    }

    public void OnBeginDrag(PointerEventData data)
    {
        originalMouseClickPos = data.position;
    }

    public void OnDrag(PointerEventData data)
    {
        imageToMove.transform.position += (Vector3) data.delta * Time.deltaTime;
    }
}
