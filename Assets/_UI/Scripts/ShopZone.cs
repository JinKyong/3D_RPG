using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    [SerializeField] GameObject ShopCrash;
    [SerializeField] GameObject ShopWindow;

    


    private void OnTriggerEnter(Collider other) // Ʈ���� ��ư
    {
        ShopCrash.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        ShopCrash.SetActive(false);
    }

    public void OncklickOk() // ���� ��ư
    {
        ShopWindow.SetActive(true);
    }

    public void Oncklickcancel() // ��� ��ư
    {
        ShopWindow.SetActive(false);
    }



   
}
