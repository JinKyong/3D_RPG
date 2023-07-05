using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPrefab : MonoBehaviour
{
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        Debug.Log("Prefab Awake");
    }

    private void OnEnable()
    {
        Debug.Log("Prefab Enable");
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Prefab Start");
    }

    public void GetAnim()
    {
        Debug.Log(anim);
    }

}
