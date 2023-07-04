using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleInput : MonoBehaviour
{
    [SerializeField] GameObject inventory;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            inventory.SetActive(true);
        }
    }
}
