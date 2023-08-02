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
            }
        }

        public void StopBGM()
        {
            audioSourceBGM.Stop();
        }
    }
}
