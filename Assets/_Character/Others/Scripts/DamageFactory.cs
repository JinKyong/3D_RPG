using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Public;
using Character;
using Character.State;

namespace Damage
{
    public class DamageFactory : Singleton<DamageFactory>
    {
        public GameObject target;
        public int dmgValue;

        [SerializeField] GameObject damageTxt;
        public int damagePoolSize = 10;
        public List<TMP_Text> damageTextPool = new List<TMP_Text>();

        private void Start()
        {
            PoolManager.Instance.Setup();
        }

        public void CalculateDmgToEnemy(GameObject other, int damage)
        {
            target = other;
            dmgValue = damage;
            other.GetComponent<Enemy0>().hp -= damage;
            other.GetComponent<Enemy0>().TakeDamage();
        }

        public void CalculateDmgToBoss(GameObject other, int damage)
        {
            target = other;
            dmgValue = damage;
            other.GetComponent<EnemyBoss>().hp -= damage;
            other.GetComponent<EnemyBoss>().TakeDamage();
        }
        public void CalculateDmgToPlayer(GameObject other, int damage)
        {            
            dmgValue = damage;
            Player.Instance.Stat.runTimeHealth -= damage;
            PlayerController.Instance.TakeDamage();
        }

        public void CreateTMP(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(damageTxt);
            obj.transform.position = pos;

            dmgValue = damage;
            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }
    }
}

