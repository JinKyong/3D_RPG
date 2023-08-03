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

        private void Start()
        {
            StartCoroutine(FadeInCoroutine());
        }

        public void PadeInButton()
        {
            lodinUi.SetActive(true);
            StartCoroutine(FadeInCoroutine());
        }

        private IEnumerator FadeInCoroutine()
        {
            float duration = 3f; // 페이드 아웃에 걸리는 시간 설정

            // 로딩 UI 페이드 아웃 애니메이션
            while (lodingCan.alpha < 1)
            {
                    lodingCan.alpha += Time.deltaTime / duration;
                bg.SetActive(true);
                yield return null;
                }
                if (lodingCan.alpha == 1)
                { 
                    // 배경 페이드 인 애니메이션
                    while (bgCan.alpha < 1)
                {
                    
                    bgCan.alpha += Time.deltaTime / duration;
                   
                    yield return null;
                }

               }

            // 로딩 바 활성화
            lodingBar.SetActive(true);
        }
    }
}
