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
        // 테스트를 위한 버튼 이벤트 추가
        public void PlayTownBGM()
        {
            PlayBGM("Town"); // Town이라는 이름의 BGM 클립을 재생
        }

        public void StopAllBGM()
        {
            SoundManager.Instance.StopBGM();
        }

        // SoundManager의 기능을 사용하기 위한 메서드
        public void PlayBGM(string name)
        {
            SoundManager.Instance.PlayBGM(name);
        }

        // 필요한 경우 볼륨 조절 기능 추가
      
    }
}
