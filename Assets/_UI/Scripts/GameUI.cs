using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace gameUI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] TMP_Text name;
        [SerializeField] TMP_Text level;
        [SerializeField] TMP_Text coin;


        private void Start()
        {
            name.text += PlayerDataManager.PlayerDataManager.Instance.nowPlayer.name;
            level.text += PlayerDataManager.PlayerDataManager.Instance.nowPlayer.level.ToString();
            coin.text += PlayerDataManager.PlayerDataManager.Instance.nowPlayer.coin.ToString();
        }
        public void LevelUp()
        {
            level.text = "레벨 : " + PlayerDataManager.PlayerDataManager.Instance.nowPlayer.level.ToString();
        }

        public void CoinUp()
        {
            level.text = "코인 : " + PlayerDataManager.PlayerDataManager.Instance.nowPlayer.coin.ToString();
        }
        public void Save()
        {

            PlayerDataManager.PlayerDataManager.Instance.SaveData();
        }
    }
}    