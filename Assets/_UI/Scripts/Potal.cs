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

  


    private void OnTriggerEnter(Collider other) // Ʈ���� ��ư
    {
        PotalZone.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        PotalZone.SetActive(false);
        /*Loadingslider.Instance.StopCoroutine();*/
    }
    public void OncklickGoVlige() // ���� ��ư
    {
        SceneManager.LoadSceneAsync(sceneNum);
        
        
    }

 
    public void OncklickPotalOk() // ���� ��ư
    {
        
        window.SetActive(true);

        /*SceneManager.LoadSceneAsync(sceneNum);*/
    }
    public void OncklickPotalNo() // ��� ��ư
    {
        window.SetActive(false);
    }

}   