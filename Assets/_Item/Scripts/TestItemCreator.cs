using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;

public class TestItemCreator : Singleton<TestItemCreator>
{
    [SerializeField] GameObject[] prefabs;

    public void Create(Vector3 pos, int index)
    {
        GameObject obj = Instantiate(prefabs[index]);
        obj.transform.position = pos;
    }
}
