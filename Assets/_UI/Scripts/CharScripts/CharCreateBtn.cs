using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharCreateBtn : MonoBehaviour
{
    [SerializeField] GameObject charObject;
    [SerializeField] Button createBtn;
    [SerializeField] Button charBtn;

    private void Start()
    {
        createBtn.onClick.AddListener(OnCreateBtnClicked);

    }
    public void OnCreateBtnClicked()
    {
        charObject.SetActive(true);
        charBtn.interactable = true;
    }
}