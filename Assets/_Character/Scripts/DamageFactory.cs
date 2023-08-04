using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Public;

namespace Damage
{
    public class DamageFactory : Singleton<DamageFactory>
    {
        [SerializeField] GameObject damageFactory;
        public int damagePoolSize = 10;
        public List<TMP_Text> damageTextPool = new List<TMP_Text>();

        private void Start()
        {
            PoolManager.Instance.Setup();
        }


        public void CreateTMP(Vector3 pos, int damage)
        {
            var obj = PoolManager.Instance.Pop(damageFactory);
            obj.transform.position = pos;

            TMP_Text tmp = obj.GetComponent<TMP_Text>();
            tmp.text = damage.ToString();
        }
    }
}

