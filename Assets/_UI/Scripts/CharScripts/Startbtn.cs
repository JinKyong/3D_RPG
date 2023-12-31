using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace StartBtn
{
    public class Startbtn : MonoBehaviour
    {
        // 클릭했을시 게임에 진입. 그리고 
        // 메인씬에서 진행해야하기에 페이드아웃을 추가해줘야함.. 비동기 페이드인.
        [SerializeField] Button startBtn;
        [SerializeField] GameObject charChoose;
        [SerializeField] CanvasGroup chooseCan;
        public void StartBtn()
        {

           StartCoroutine(FadeOutCoroutine());
        }

        private IEnumerator FadeOutCoroutine()
        {
            float duration = 1f; // 페이드 아웃에 걸리는 시간 설정

            while (chooseCan.alpha > 0)
            {
                chooseCan.alpha -= Time.deltaTime / duration;
                yield return null;
            }

            charChoose.SetActive(false);
        }
    }

}
