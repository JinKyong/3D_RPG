using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Public;
using Character.State;


namespace Character
{
    public class Player : Singleton<Player>
    {
        [SerializeField] PlayerStat playerStat;
        public PlayerStat Stat { get { return playerStat; } }

        [SerializeField] PlayerController playerController;

        public void Hit()
        {
            playerController.IsDamaged = true;
        }

        // �������̽� â�� �� �� �ֵ��� �ϴ� �����
    }
}