using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace PlayerName
{ 
    public class PlayerName: MonoBehaviour
    {
        private Transform target;
        [SerializeField] TMP_Text name;
        private void Start()
        {
            name.text += PlayerDataManager.PlayerDataManager.Instance.nowPlayer.name;
            target = Camera.main.gameObject.transform;
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.LookRotation(target.forward, target.up);
        }
    }
}

