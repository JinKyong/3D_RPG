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
                slotText[i].text = "비어있음";
            }
        }
        
    }

    // 슬롯이 4개. 그런데 어떻게 알맞은걸 가져올까?
    public void Slot(int number)
    {
        
        PlayerDataManager.PlayerDataManager.Instance.nowSlot = number;
        // 1. 저장된 데이터가 없을떄

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
