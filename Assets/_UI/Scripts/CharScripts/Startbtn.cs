using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StartBtn
{
    public class Startbtn : MonoBehaviour
    {
        // Ŭ�������� ���ӿ� ����. �׸��� 
        // ���ξ����� �����ؾ��ϱ⿡ ���̵�ƿ��� �߰��������.. �񵿱� ���̵���.
        [SerializeField] Button startBtn;
        [SerializeField] GameObject charChoose;
        [SerializeField] CanvasGroup chooseCan;
        public void StartBtn()
        {

           StartCoroutine(FadeOutCoroutine());
        }

        private IEnumerator FadeOutCoroutine()
        {
            float duration = 1f; // ���̵� �ƿ��� �ɸ��� �ð� ����

            while (chooseCan.alpha > 0)
            {
                chooseCan.alpha -= Time.deltaTime / duration;
                yield return null;
            }

            charChoose.SetActive(false);
        }
    }

}
