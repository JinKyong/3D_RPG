using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Item.Data;

public class testScripts : MonoBehaviour
{
    public ItemData data;
    // Start is called before the first frame update
    void Start()
    {
        data = AssetDatabase.LoadAssetAtPath<ItemData>("Assets/_Skill/Scripts/SamplePotion.asset");
        //AssetDatabase.load
    }

}
