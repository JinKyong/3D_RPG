using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Damage
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] int damage;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Enemy0"))
            {
                DamageFactory.Instance.CalculateDmgToEnemy(other, damage);
                
                Vector3 pos = other.transform.position;
                pos.y += other.GetComponent<CapsuleCollider>().height;
                DamageFactory.Instance.CreateTMP(pos, damage);
            }
            else if (other.CompareTag("EnemyBoss"))
            {
                DamageFactory.Instance.CalculateDmgToBoss(other, damage);

                Vector3 pos = other.transform.position;
                pos.y += other.GetComponent<CapsuleCollider>().height;
                DamageFactory.Instance.CreateTMP(pos, damage);
            }
        }
    }
}