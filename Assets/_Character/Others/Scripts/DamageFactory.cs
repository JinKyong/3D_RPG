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
            var enemy0 = other.GetComponent<Enemy0>();
            if (enemy0.IsDamaged)
            {
                return;
            }

            enemy0.TakeDamage();
            // 데미지 전달
            target = other;
            dmgValue = damage;
            enemy0.ControlStat(-dmgValue);
            // 데미지 텍스트 전달
            Vector3 pos = other.transform.position;
            pos.y += other.GetComponent<CapsuleCollider>().height;
            createPdmgText(pos, dmgValue);            
        }

        public void CalculateDmgToBoss(GameObject other, int damage)
        {
            var enemyBoss = other.GetComponent<EnemyBoss>();
            if (enemyBoss.IsDamaged)
            {
                return;
            }

            enemyBoss.TakeDamage();
            target = other;
            dmgValue = damage;
            enemyBoss.ControlStat(-dmgValue);

            Vector3 pos = other.transform.position;
            pos.y += other.GetComponent<CapsuleCollider>().height;
            createPdmgText(pos, dmgValue);

        }

        public void CalculateDmgToPlayer(int damage)
        {
            if (PlayerController.Instance.IsDamaged)
            {
                return;
            }

            PlayerController.Instance.TakeDamage();
            dmgValue = damage;
            Player.Instance.ControlStat(-damage, 0);

            Vector3 pos = Player.Instance.transform.position;
            pos.y += Player.Instance.GetComponent<CapsuleCollider>().height;
            createEdmgText(pos, dmgValue);
        }

        private void createPdmgText(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(PdamageTxt);
            obj.transform.position = pos;
            
            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }

        private void createEdmgText(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(EdamageTxt);
            obj.transform.position = pos;

            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }

    }
}

