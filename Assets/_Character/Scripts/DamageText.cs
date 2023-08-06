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
        // �ؽ�Ʈ�� �������� �̵�
        transform.Translate(Vector3.up * Time.deltaTime);

        // �ؽ�Ʈ�� ���� ����ȭ
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
