using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    Transform target;

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        transform.forward = target.forward;
    }
}
