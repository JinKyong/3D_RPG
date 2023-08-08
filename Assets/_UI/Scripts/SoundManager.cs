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
            loading,
            Village,
            Game
           
        }
        /*EScene scene;*/

        [SerializeField] AudioMixer audiomixer;
        [SerializeField] Slider volumeSlider;
        [SerializeField] Slider MasterSlider;
        [SerializeField] Toggle Mute;

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
                case (int)EScene.Main:
                    PlayBGM("Login");
                    break;
                case (int)EScene.loading:
                    PlayBGM("Null");
                    break;
                   
                case (int)EScene.Village:
                    PlayBGM("Town");
                    break;
                case (int)EScene.Game:
                    PlayBGM("Battle");
                    break;

                default:
                    //Debug.Log("�߸��� ���� ���Խ��ϴ�.");
                    //����ó��
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
        public void SetMasterVolume()
        {   
            float value = MasterSlider.value;
            audiomixer.SetFloat("Master", value);

        }
        public void SetMute(bool isOn, bool isOff)
        {
            
            isOn = Mute.isOn;


            /*bool Btn = anim.GetBool("VolumeBtn");
            anim.SetBool("VolumeBtn", !Btn);*/

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
                Debug.Log(_name + " ���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
            }
        }

        public void StopBGM()
        {
            audioSourceBGM.Stop();
        }
    }
}
