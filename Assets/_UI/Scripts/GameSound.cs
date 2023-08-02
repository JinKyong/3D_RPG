using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Soundmanager;
using Public;

namespace N.GameSound
{
    public class GameSound : Singleton<GameSound>
    {
        private void Awake()
        {
            RegisterInstance();
             /* audioSourceBGM = GetComponent<AudioSource>();*/
        }
        // �׽�Ʈ�� ���� ��ư �̺�Ʈ �߰�
        public void PlayTownBGM()
        {
            PlayBGM("Town"); // Town�̶�� �̸��� BGM Ŭ���� ���
        }

        public void StopAllBGM()
        {
            SoundManager.Instance.StopBGM();
        }

        // SoundManager�� ����� ����ϱ� ���� �޼���
        public void PlayBGM(string name)
        {
            SoundManager.Instance.PlayBGM(name);
        }

        // �ʿ��� ��� ���� ���� ��� �߰�
      
    }
}
