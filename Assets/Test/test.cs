using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Test
{
    public class test : MonoBehaviour
    {
        public GameObject prefab;

        public void instance()
        {
            testPrefab obj = Instantiate(prefab).GetComponent<testPrefab>();
            Debug.Log("Create");
            obj.GetAnim();
        }
    }
}