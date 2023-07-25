using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Zone : MonoBehaviour
{
    [SerializeField] GameObject Crash;

    [SerializeField] int sceneNumber = 0;


    private void OnTriggerEnter(Collider other)
    {
        Crash.SetActive(true);
    }
    public void Oncklickcancel()
    {
        Crash.SetActive(false);
    }

    public void OncklickStage()
    {
        SceneManager.LoadSceneAsync(sceneNumber);
    }
}
