using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UnLock
{ 

    public class UnLock : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI asdfadsf;
        [SerializeField] GameObject objectToDeactivate;
        [SerializeField] Button charBtn;
        [SerializeField] GameObject SelectImage;

        bool Selectimage = false;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {

                if (!SelectImage)
                {
                    SelectImage.SetActive(true);
                }
            }
        }
        private void Start()
        {
            charBtn.onClick.AddListener(OnCreateChar);
        }

        public void OnCreateChar()
        {
            objectToDeactivate.SetActive(false);
           
        }
    }

}