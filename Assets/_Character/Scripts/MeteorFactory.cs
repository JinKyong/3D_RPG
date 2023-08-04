using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

namespace Player.Skill
{
    public class MeteorFactory : Singleton<MeteorFactory>
    {
        [SerializeField] GameObject meteor;
        public int poolSize = 10;
        public List<GameObject> meteorPool = new List<GameObject>();

        private void Start()
        {
            PoolManager.Instance.Setup();
        }

        public void CreateMeteor(Vector3 pos)
        {
            var obj = PoolManager.Instance.Pop(meteor);
            obj.SetActive(true);
            obj.transform.position = pos;
        }
    }
}