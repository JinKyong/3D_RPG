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

        [SerializeField] GameObject PdamageTxt;
        [SerializeField] GameObject EdamageTxt;

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
            other.GetComponent<Enemy0>().ControlStat(-damage);
            other.GetComponent<Enemy0>().TakeDamage();
        }

        public void CalculateDmgToBoss(GameObject other, int damage)
        {
            target = other;
            other.GetComponent<EnemyBoss>().ControlStat(-damage);
            other.GetComponent<EnemyBoss>().TakeDamage();
        }
        public void CalculateDmgToPlayer(int damage)
        {            
            dmgValue = damage;
            Player.Instance.ControlStat(-damage, 0);
            PlayerController.Instance.TakeDamage();
        }

        public void CreatePdmgText(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(PdamageTxt);
            obj.transform.position = pos;

            dmgValue = damage;
            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }

        public void CreateEdmgText(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(EdamageTxt);
            obj.transform.position = pos;

            dmgValue = damage;
            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }

    }
}

