using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace LoadingSlider
{ 
    public class Loadingslider : MonoBehaviour 
    {
        [SerializeField] int sceneNumber = 0;
        [SerializeField] Slider progressBar;
        [SerializeField] TMP_Text progressBarText;
        [SerializeField] Image Image;    // 검은화면

        [SerializeField] GameObject loadingUi;
        [SerializeField] CanvasGroup loadingCanEnd;

   /*     private float loadingProgress = 0f;
        private float fillSpeed = 0.4f;
        private bool isPaused = false;*/


    
    
        private void Start()
        {
            /*StartCoroutine(RandomPauseCoroutine());*/
            StartCoroutine(StartLoadingCoroutine(sceneNumber));
       
        }

        private IEnumerator StartLoadingCoroutine(int num)
        {
        
            yield return new WaitForSeconds(2f); // 2초 대기

            AsyncOperation ao = SceneManager.LoadSceneAsync(num);

            ao.allowSceneActivation = false;
            while(!ao.isDone)
            {
                progressBar.value = ao.progress;
                progressBarText.text = (ao.progress * 100f).ToString() + '%';

                if (ao.progress >= 0.9f)
                {
                    ao.allowSceneActivation = true;
                }
                yield return null;
            }
       
        /*    while (loadingProgress < 1f )
            {
                if (!isPaused)
                {
                    loadingProgress += fillSpeed * Time.deltaTime;
                }

                progressBar.value = loadingProgress;

                yield return null;
            }

            if (loadingProgress >= 1f)
            {
                float duration = 2f;
                // 다음 ui로 전환
            
                while (lodingCanEnd.alpha >= 0)
                {
                    lodingCanEnd.alpha -= Time.deltaTime / duration;
                    if (progressBar.value > 1)
                    {
                        lodingUi.SetActive(false);
                    }
                
                    yield return null;
                }
                yield return new WaitForSeconds(0.5f); // 0.5초 대기*/

         
           
            }
        }
    }




