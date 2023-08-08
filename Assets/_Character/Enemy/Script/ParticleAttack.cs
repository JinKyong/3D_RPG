using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;

namespace Damage
{
    public class ParticleAttack : MonoBehaviour
    {
        [SerializeField] int damage;

        private void OnParticleCollision(GameObject other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy0>().GetDamage(damage);
                Vector3 pos = other.transform.position;
                pos.y += other.GetComponent<CapsuleCollider>().height;
                DamageFactory.Instance.CreateTMP(pos, damage);
            }
        }
    }
}