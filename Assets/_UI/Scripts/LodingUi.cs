using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


namespace LodingUi
{ 
    public class LodingUi : MonoBehaviour
    {
        [SerializeField] Image backGround;
        [SerializeField] GameObject button;

        public void Padebutton()
        {
            Debug.Log("버튼클릭");
            button.SetActive(false);
            StartCoroutine(FadeCrootrine());
        }
        IEnumerator FadeCrootrine()
        {
            float fadeCount = 0;
            while (fadeCount < 1f)
            {
                fadeCount += 0.01f;
                yield return new WaitForSeconds(0.01f);
                backGround.color = new Color(0, 0, 0, fadeCount);
            
            }
        }


    }
}