using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Public;
using System.IO;




public class SelectChar : MonoBehaviour
{
    [SerializeField] GameObject creat;    
    [SerializeField] TMP_Text[] slotText;
    [SerializeField] TMP_Text newPlyerName;

    bool[] savefile = new bool[4];

    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            if (File.Exists(DataManager.PlayerDataManager.Instance.path + $"{i}"))
            {
                savefile[i] = true;
                DataManager.PlayerDataManager.Instance.nowSlot = i;
                DataManager.PlayerDataManager.Instance.LoadData();
                slotText[i].text = DataManager.PlayerDataManager.Instance.nowPlayer.name;
                

            }
            else
            {
                slotText[i].text = "�������";
            }
        }
        DataManager.PlayerDataManager.Instance.DataClear();
    }

    // ������ 4��. �׷��� ��� �˸����� �����ñ�?
    public void Slot(int number)
    {
        
        DataManager.PlayerDataManager.Instance.nowSlot = number;
        // 1. ����� �����Ͱ� ������

        if (savefile[number])
        {
            DataManager.PlayerDataManager.Instance.LoadData();
            GoLoding();
            
        }
        else
        {
            Creat(); 
        }
   

    }

    public void Creat()
    {
        creat.gameObject.SetActive(true);
    }
    public void GoLoding()
    {
        if (!savefile[DataManager.PlayerDataManager.Instance.nowSlot])
        {
            DataManager.PlayerDataManager.Instance.nowPlayer.name = newPlyerName.text;
            DataManager.PlayerDataManager.Instance.SaveData();
        }
        
        SceneManager.LoadScene(1);
    }
  /*  private void StartLoding()
    {
           Debug.Log("����!");
          GameObject.Find("LodingUI").GetComponent<LodingUi.LodingUi>().FadeInCoroutine();
    }
  */
}