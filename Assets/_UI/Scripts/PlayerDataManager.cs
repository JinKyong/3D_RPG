using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using System.IO;                 // 인풋 아웃풋



// 저장하는 방법
// 1. 저장할 데이터가 존재
// 2. 데이터를 제이슨으로 변환
// 3. 제이슨을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터 형태로 변환
// 3. 불러온 데이터를 사용

// 슬롯별로 다르게 저장.

namespace DataManager
{
    public class PlayerData
    {
        public string name;       // 플레이어 닉네임
        public int level = 1;     // 플레이어 레벨
        public int coin = 100;    // 돈
    }
    

    public class PlayerDataManager : Singleton<PlayerDataManager>    //싱글톤을 받아서 만듬.
    {
        public PlayerData nowPlayer = new PlayerData(); 
        public  string path;
        
        public int nowSlot;

        private void Awake()
        {
            RegisterInstance();

            path = Application.persistentDataPath + "/save";
            print(path);
        }

        
        public string UseID { get; set; }

        private void Start()
        {
           /*string data = JsonUtility.ToJson(nowPlayer);
            print(path);
            *//*print(data);*//*
            File.WriteAllText(path , data);*/

            int count = FindObjectsOfType<PlayerDataManager>().Length;
            if (count > 1)
            {
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }
        public void SaveData()
        {
            string data = JsonUtility.ToJson(nowPlayer);
            File.WriteAllText(path + nowSlot.ToString(), data);
        }
        public void LoadData()
        {
            string data = File.ReadAllText(path +  nowSlot.ToString());
            nowPlayer = JsonUtility.FromJson<PlayerData>(data);
        }
        public void DataClear()
        {
            nowSlot = -1;
            nowPlayer = new PlayerData();
        }
    }

}