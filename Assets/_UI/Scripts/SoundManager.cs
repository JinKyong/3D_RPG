using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main.Sound
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]AudioSource bgSound;
        [SerializeField] AudioClip[] bgList;
        public static SoundManager instance;
        private void Awake()
        {

            SceneManager.sceneLoaded += OneSceneLoaded;
           /* if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
            else
            {
                Destroy(gameObject);
            }*/
          

        }

        private void OneSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            for (int i = 0; i < bgList.Length; i++)
            {
                if (arg0.name == bgList[i].name)
                    BgSoundPlay(bgList[i]);
                
            }

           
        }

        public void BgSoundPlay(AudioClip clip)
        {
            bgSound.clip = clip;
            bgSound.loop = true;
            bgSound.volume = 0.1f;
            bgSound.Play();
        }

        /* [SerializeField]AudioSource bgMusic;         // 배경 음악을 재생하는 AudioSource 컴포넌트를 참조하는 변수

         public void SetMusicVolume(float volume)
         {
             bgMusic.volume = volume;         // 전달받은 볼륨 값을 배경 음악의 볼륨에 할당
         }*/
    }
}
