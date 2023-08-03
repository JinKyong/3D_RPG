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


        private void OnTriggerEnter(Collider other) // Ʈ���� ��ư
        {
            Crash.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            Crash.SetActive(false);
        }

        public void OncklickOk() // ���� ��ư
        {
            Window.SetActive(true);
        }

        public void Oncklickcancel() // ��� ��ư
        {
            Window.SetActive(false);
        }

       

        public void OncklickStageSene() // ������ ������ �� ������ �̵�.
        {
            SceneManager.LoadSceneAsync(sceneNumber);
        }
    }
}