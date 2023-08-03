using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LodingUi
{
    public class LodingUi : MonoBehaviour
    {
        [SerializeField] GameObject lodinUi;
        [SerializeField] GameObject bg;
        [SerializeField] GameObject lodingBar;
        [SerializeField] CanvasGroup lodingCan;
        [SerializeField] CanvasGroup bgCan;

    /*    private void Start()
        {
            StartCoroutine(FadeInCoroutine());
        }*/

        public void PadeInButton()
        {
            lodinUi.SetActive(true);
            StartCoroutine(FadeInCoroutine());
        }

        private IEnumerator FadeInCoroutine()
        {
            float duration = 3f; // ���̵� �ƿ��� �ɸ��� �ð� ����

            // �ε� UI ���̵� �ƿ� �ִϸ��̼�
            while (lodingCan.alpha < 1)
            {
                    lodingCan.alpha += Time.deltaTime / duration;
                bg.SetActive(true);
                yield return null;
                }
                if (lodingCan.alpha == 1)
                { 
                    // ��� ���̵� �� �ִϸ��̼�
                    while (bgCan.alpha < 1)
                {
                    
                    bgCan.alpha += Time.deltaTime / duration;
                   
                    yield return null;
                }

               }

            // �ε� �� Ȱ��ȭ
            lodingBar.SetActive(true);
        }
    }
}
