using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testDestroy : MonoBehaviour
{
    public List<GameObject> testList;

    // Start is called before the first frame update
    void Start()
    {
        testList = new List<GameObject>();
        for (int i = 0; i < 10; i++)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(transform);
            obj.name = "Object" + i;
            testList.Add(obj);
        }
    }

    public void Remove()
    {
        foreach (var obj in testList)
        {
            testList.Remove(obj);
            Destroy(obj);
        }
    }
}
