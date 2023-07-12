using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CharCreateBtn
{ 
    public class CharCreateBtn : MonoBehaviour
    {
        [SerializeField] GameObject charObject;
        [SerializeField] GameObject nickNameObj;
        
        [SerializeField] Button createBtn;
        [SerializeField] Button charBtn;
     
        private void Start()
        {
        createBtn.onClick.AddListener(OnCreateBtnClicked);

            }
        public void OnCreateBtnClicked()
        {   

            charObject.SetActive(false);
        
            charBtn.interactable = true;

            nickNameObj.SetActive(true);
         
        }
    
    }

}