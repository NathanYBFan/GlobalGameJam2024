using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableUIWorldSpace : MonoBehaviour, IDragHandler
{
    [SerializeField]
    private Canvas parentCanvasOfImageToMove;
    
    [SerializeField]
    private GameObject imageToMove;

    private void Start()
    {
        parentCanvasOfImageToMove.worldCamera = Camera.main;
    }

    public void OnDrag(PointerEventData data)
    {
        imageToMove.transform.position += (Vector3) data.delta * Time.deltaTime  * 6;
    }
}
