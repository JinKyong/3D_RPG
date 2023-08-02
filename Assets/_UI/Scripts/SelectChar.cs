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
            if (File.Exists(PlayerDataManager.PlayerDataManager.Instance.path + $"{i}"))
            {
                savefile[i] = true;
                PlayerDataManager.PlayerDataManager.Instance.nowSlot = i;
                PlayerDataManager.PlayerDataManager.Instance.LoadData();
                slotText[i].text = PlayerDataManager.PlayerDataManager.Instance.nowPlayer.name;
                PlayerDataManager.PlayerDataManager.Instance.DataClear();

            }
            else
            {
                slotText[i].text = "�������";
            }
        }
        
    }

    // ������ 4��. �׷��� ��� �˸����� �����ñ�?
    public void Slot(int number)
    {
        
        PlayerDataManager.PlayerDataManager.Instance.nowSlot = number;
        // 1. ����� �����Ͱ� ������

        if (savefile[number])
        {
            PlayerDataManager.PlayerDataManager.Instance.LoadData();
            GoGame();
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
    public void GoGame()
    {
        if (!savefile[PlayerDataManager.PlayerDataManager.Instance.nowSlot])
        {
            PlayerDataManager.PlayerDataManager.Instance.name = newPlyerName.text;
            PlayerDataManager.PlayerDataManager.Instance.SaveData();
        }
        
        SceneManager.LoadScene(2);
    }

  
}
