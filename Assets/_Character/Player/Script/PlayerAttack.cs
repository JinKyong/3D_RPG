using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Damage
{
    public class PlayerAttack : MonoBehaviour
    {
        public int damage;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Enemy0"))
            {
                DamageFactory.Instance.CalculateDmgToEnemy(other, damage);               
            }
            else if (other.CompareTag("EnemyBoss"))
            {
                DamageFactory.Instance.CalculateDmgToBoss(other, damage);
            }
        }
    }
}