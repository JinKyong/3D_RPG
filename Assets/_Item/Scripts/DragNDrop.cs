using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Item.Event
{
    public class DragNDrop : MonoBehaviour,
        IBeginDragHandler, IEndDragHandler, IDragHandler
    {
        [SerializeField] RectTransform targetTransform;
        //CanvasGroup canvasGroup;
        [SerializeField] Canvas canvas;
        private void Awake()
        {
            //rectTransform = GetComponent<RectTransform>();
            //canvasGroup = GetComponent<CanvasGroup>();
        }


        public void OnBeginDrag(PointerEventData eventData)
        {
            //canvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            // ���� �̵��� ���ؼ� �󸶳� �̵��ߴ����� ������
            // ĵ������ �����ϰ� ����� �ϱ� ������
            targetTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            //canvasGroup.blocksRaycasts = true;
        }
    }
}
