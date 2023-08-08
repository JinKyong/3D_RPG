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
        enum EScene
        {
            Main,
            Game,
            Village
        }
        EScene scene;

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
            scene = EScene.Game;
            switch (scene)
            {
                case EScene.Main:
                case EScene.Game:
                    PlayBGM("Login");
                    break;
                case EScene.Village:
                    PlayBGM("Login");
                    break;

                default:
                    //Debug.Log("잘못된 값이 들어왔습니다.");
                    //예외처리
                    break;
            }

           /* switch (nextScene.buildIndex)
            {
                case :
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
            }*/
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
