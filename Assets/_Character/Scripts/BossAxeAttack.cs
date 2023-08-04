using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Item.Data
{
    public class BossAxeAttack : MonoBehaviour
    {
        [SerializeField] BoxCollider leftAxe;
        [SerializeField] BoxCollider rightAxe;

        private void Start()
        {
            leftAxe.enabled = false;
            rightAxe.enabled = false;
        }

        public void ActivateRightAxe()
        {
            rightAxe.enabled = true;            
        }

        public void ActivateLeftAxe()
        {
            leftAxe.enabled = true;
            rightAxe.enabled = false;
        }
        public void InactivateAxes()
        {
            leftAxe.enabled = false;
            rightAxe.enabled = false;
        }
    }

}
