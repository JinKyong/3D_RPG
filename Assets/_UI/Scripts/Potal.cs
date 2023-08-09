using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using LoadingSlider;
using UnityEngine.UI;


public class Potal : MonoBehaviour
{

    [SerializeField] GameObject PotalZone;
    [SerializeField] GameObject window;
    [SerializeField] int sceneNum;

  


    private void OnTriggerEnter(Collider other) // 트리거 버튼
    {
        PotalZone.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        PotalZone.SetActive(false);
        /*Loadingslider.Instance.StopCoroutine();*/
    }
    public void OncklickGoVlige() // 수락 버튼
    {
        SceneManager.LoadSceneAsync(sceneNum);
        
        
    }

 
    public void OncklickPotalOk() // 수락 버튼
    {
        
        window.SetActive(true);

        /*SceneManager.LoadSceneAsync(sceneNum);*/
    }
    public void OncklickPotalNo() // 취소 버튼
    {
        window.SetActive(false);
    }

}   