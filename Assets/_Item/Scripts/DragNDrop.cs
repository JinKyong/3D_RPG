using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item.Event
{
    public class DragNDrop : MonoBehaviour,
        IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        RectTransform rectTransform;
        CanvasGroup canvasGroup;
        [SerializeField] Canvas canvas;
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvasGroup = GetComponent<CanvasGroup>();
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            //canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // 이전 이동과 비교해서 얼마나 이동했는지를 보여줌
            // 캔버스의 스케일과 맞춰야 하기 때문에
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //canvasGroup.blocksRaycasts = true;
        }
    }
}
