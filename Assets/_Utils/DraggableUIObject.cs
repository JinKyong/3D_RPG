
using Public;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Drag
{
    public class DraggableUIObject : MonoBehaviour, IDraggable
    {
        [Header("Event")]
        [SerializeField] GameEvent onDragEvent;
        [SerializeField] GameEvent offDragEvent;

        [Header("TargetUI")]
        [Space]
        [SerializeField] RectTransform targetTransform;
        [SerializeField] Canvas canvas;
        Vector3 originPos;

        public void OnBeginDrag(PointerEventData eventData)
        {
            originPos = transform.position;
            onDragEvent.Raise();
        }

        public void OnDrag(PointerEventData eventData)
        {
            targetTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            transform.position = originPos;
            offDragEvent.Raise();
        }
    }
}
