<<<<<<< Updated upstream
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Public;

namespace Soundmanager
{
    public class SoundManager : Singleton<SoundManager>
    {
        [SerializeField] AudioMixer audiomixer;
        [SerializeField] Slider volumeSlider;

        [SerializeField] List<Sound> bgmSounds;

        [SerializeField] AudioSource audioSourceBGM;

        private Dictionary<string, AudioClip> bgmClips;

        [System.Serializable]
        public class Sound
        {
            public string name;
            public AudioClip clip;
        }

        private void Awake()
        {
            RegisterInstance();
        }

        private void Start()
        {
            SceneManager.activeSceneChanged += OnSceneChanged;
            bgmClips = new Dictionary<string, AudioClip>();

            foreach (Sound sound in bgmSounds)
            {
                bgmClips[sound.name] = sound.clip;
            }
        }
        private void OnSceneChanged(Scene prevScene, Scene nextScene)
        {
            switch (nextScene.buildIndex)
            {
                case 0:
                    PlayBGM("Login");
                    break;
                case 1:
                    PlayBGM(null);
                    break;
                case 2:
                    PlayBGM("Town");
                    break;
                case 3:
                    PlayBGM("Battle");
                    break;
            }
        }
        private void OnDestroy()
        {
            SceneManager.activeSceneChanged -= OnSceneChanged;
        }

        public void SetVolume()
        {
            float value = volumeSlider.value;
            audiomixer.SetFloat("BGM", value);
        }

        public void PlayBGM(string _name)
        {
            if (bgmClips.TryGetValue(_name, out AudioClip clip))
            {
                audioSourceBGM.clip = clip;
                audioSourceBGM.Play();
            }
            else
            {
                Debug.Log(_name + " 사운드가 SoundManager에 등록되지 않았습니다.");
=======
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
                
>>>>>>> Stashed changes
            }

           
        }

<<<<<<< Updated upstream
        public void StopBGM()
        {
            audioSourceBGM.Stop();
        }
=======
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
>>>>>>> Stashed changes
    }
}
