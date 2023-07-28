using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerName
{ 
    public class PlayerName: MonoBehaviour
    {
        private Transform target;

        private void Start()
        {
            target = Camera.main.gameObject.transform;
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(target.forward, target.up);
        }
    }
}

