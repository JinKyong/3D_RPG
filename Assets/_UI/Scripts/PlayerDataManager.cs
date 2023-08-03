using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using System.IO;                 // ��ǲ �ƿ�ǲ



// �����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� ���̽����� ��ȯ
// 3. ���̽��� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ������ ���·� ��ȯ
// 3. �ҷ��� �����͸� ���

// ���Ժ��� �ٸ��� ����.

namespace PlayerDataManager
{
    public class PlayerData
    {
        public string name;       // �÷��̾� �г���
        public int level = 1;     // �÷��̾� ����
        public int coin = 100;    // ��
    }
    

    public class PlayerDataManager : Singleton<PlayerDataManager>    //�̱����� �޾Ƽ� ����.
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