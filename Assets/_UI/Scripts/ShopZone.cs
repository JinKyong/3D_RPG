using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    [SerializeField] GameObject ShopCrash;
    [SerializeField] GameObject ShopWindow;

    


    private void OnTriggerEnter(Collider other) // 트리거 버튼
    {
        ShopCrash.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ShopCrash.SetActive(false);
    }

    public void OncklickOk() // 수락 버튼
    {
        ShopWindow.SetActive(true);
    }

    public void Oncklickcancel() // 취소 버튼
    {
        ShopWindow.SetActive(false);
    }



   
}
