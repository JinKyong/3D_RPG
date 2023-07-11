using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnLock : MonoBehaviour
{
    [SerializeField] GameObject objectToDeactivate;
    [SerializeField] Button charBtn;

    private void Start()
    {
        charBtn.onClick.AddListener(OnCreateChar);
    }

    public void OnCreateChar()
    {
        objectToDeactivate.SetActive(false);
    }
}
