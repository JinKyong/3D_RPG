using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Damage
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] int damage;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Player"))
            {
                DamageFactory.Instance.CalculateDmgToPlayer(other, damage);
                
                Vector3 pos = other.transform.position;
                pos.y += other.GetComponent<CapsuleCollider>().height;
                DamageFactory.Instance.CreateTMP(pos, damage);
            }

        }
    }
}