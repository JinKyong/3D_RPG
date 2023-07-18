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
        [SerializeField] float fadeInDuration = 2.5f; // ���̵��� �ð� ���� ����
        [SerializeField] float fadeOutDuration = 2.5f; // ���̵�ƿ� �ð� ���� ����

        public void Start()
        {
            StartCoroutine(FadeInCoroutine());

            
        }

        private  IEnumerator FadeInCoroutine()
        {
            // ���̵��� �ִϸ��̼� ����
            inFade.SetActive(true);
            backGround.GetComponent<Image>().canvasRenderer.SetAlpha(1f);
            backGround.GetComponent<Image>().CrossFadeAlpha(0f, fadeInDuration, false);

            // ���̵����� ���� ������ ���
            yield return new WaitForSeconds(fadeInDuration);

            // ���̵��� ������Ʈ ��Ȱ��ȭ
            inFade.SetActive(false);

           
        }

        private IEnumerator FadeOutCoroutine()
        {
            // ���̵�ƿ� �ִϸ��̼� ����
            outFade.SetActive(true);
            backGround.GetComponent<Image>().canvasRenderer.SetAlpha(0f);
            backGround.GetComponent<Image>().CrossFadeAlpha(1f, fadeOutDuration, false);

            // ���̵�ƿ��� ���� ������ ���
            yield return new WaitForSeconds(fadeOutDuration);

            // ���̵�ƿ� ������Ʈ ��Ȱ��ȭ
            outFade.SetActive(false);
        }
    }
  
}