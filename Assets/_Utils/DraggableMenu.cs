using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Utils.Drag
{
    public class DraggableMenu : MonoBehaviour, IDraggable
    {
        [SerializeField] RectTransform targetTransform;
        [SerializeField] Canvas canvas;

        public void OnBeginDrag(PointerEventData eventData)
        {

        }

        public void OnDrag(PointerEventData eventData)
        {
            targetTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {

        }
    }
}
