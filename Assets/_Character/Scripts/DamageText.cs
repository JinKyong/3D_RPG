using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Public;

public class DamageText : MonoBehaviour
{
    TMP_Text dmgText;
    [SerializeField] float transparencySpeed;
    [SerializeField] float timeCount;
    [SerializeField] float removeTime;
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

        TextIntoPool();
    }

    // �����ð� ������ ������Ʈ Ǯ�� �ֱ� - �ڷ�ƾ����
    private void TextIntoPool()
    {
        timeCount += Time.deltaTime;
        if (timeCount > removeTime)
        {
            PoolManager.Instance.Push(gameObject);
            timeCount = 0;
        }
    }
}
