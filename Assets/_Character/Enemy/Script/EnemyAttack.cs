using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character.State;

namespace Damage
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] int damage;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player") && !PlayerController.Instance.IsDamaged)
            {
                DamageFactory.Instance.CalculateDmgToPlayer(damage);
            }
        }
    }
}