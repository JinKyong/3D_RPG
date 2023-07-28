using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Zone
{ 
    public class Zone : MonoBehaviour
    {
        [SerializeField] GameObject Crash;
        [SerializeField] GameObject Window;

        [SerializeField] int sceneNumber = 0;


        private void OnTriggerEnter(Collider other) // 트리거 버튼
        {
            Crash.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            Crash.SetActive(false);
        }

        public void OncklickOk() // 수락 버튼
        {
            Window.SetActive(true);
        }

        public void Oncklickcancel() // 취소 버튼
        {
            Window.SetActive(false);
        }

       

        public void OncklickStageSene() // 오케이 누르면 그 씬으로 이동.
        {
            SceneManager.LoadSceneAsync(sceneNumber);
        }
    }
}