using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Public;

public class DamageText : MonoBehaviour
{
    TMP_Text dmgText;
    [SerializeField] float transparencySpeed;
    Color txtColor;


    void Start()
    {
        dmgText = GetComponent<TMP_Text>();
        txtColor = dmgText.color;
    }

    void Update()
    {
        // 텍스트를 위쪽으로 이동
        transform.Translate(Vector3.up * Time.deltaTime);

        // 텍스트를 점차 투명화
        txtColor.a = Mathf.Lerp(txtColor.a, 0, transparencySpeed * Time.deltaTime);
        dmgText.color = txtColor;

        StartCoroutine(TextIntoPool());
    }

    IEnumerator TextIntoPool()    
    {
        yield return new WaitForSeconds(4f);
        PoolManager.Instance.Push(gameObject);        
    }    

}
