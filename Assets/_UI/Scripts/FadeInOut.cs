using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FadeInout
{ 
    public class FadeInOut : MonoBehaviour
    {
        [SerializeField] Image backGround;
        [SerializeField] GameObject inFade;
        [SerializeField] GameObject outFade;
        [SerializeField] float fadeInDuration = 2.5f; // 페이드인 시간 설정 변수
        [SerializeField] float fadeOutDuration = 2.5f; // 페이드아웃 시간 설정 변수

        public void Start()
        {
            StartCoroutine(FadeInCoroutine());

            
        }

        private  IEnumerator FadeInCoroutine()
        {
            // 페이드인 애니메이션 시작
            inFade.SetActive(true);
            backGround.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
            backGround.GetComponent<Image>().CrossFadeAlpha(0f, fadeInDuration, false);

            // 페이드인이 끝날 때까지 대기
            yield return new WaitForSeconds(fadeInDuration);

            // 페이드인 오브젝트 비활성화
            inFade.SetActive(false);

           
        }

        private IEnumerator FadeOutCoroutine()
        {
            // 페이드아웃 애니메이션 시작
            outFade.SetActive(true);
            backGround.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
            backGround.GetComponent<Image>().CrossFadeAlpha(1f, fadeOutDuration, false);

            // 페이드아웃이 끝날 때까지 대기
            yield return new WaitForSeconds(fadeOutDuration);

            // 페이드아웃 오브젝트 비활성화
            outFade.SetActive(false);
        }
    }
  
}