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
        [SerializeField] Toggle bgmMute;
        [SerializeField] Toggle masterMute;

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
            masterMute.isOn = IsMasterMute();
            masterMute.onValueChanged.AddListener(SetMasterMute);

            bgmMute.isOn = IsBgmMute();
            bgmMute.onValueChanged.AddListener(SetBgmMute);

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
        public void SetMasterVolume()
        {
            float value = MasterSlider.value;
            audiomixer.SetFloat("Master", value);

        }
        private bool IsMasterMute()
        {
            audiomixer.GetFloat("Master", out float bgmVoluem);
            return bgmVoluem <= -80f;


            /*bool Btn = anim.GetBool("VolumeBtn");
            anim.SetBool("VolumeBtn", !Btn);*/
        }
        private void SetMasterMute(bool isMute)
        {
            audiomixer.SetFloat("Master", isMute ? -80f : 0f);

            /*bool Btn = anim.GetBool("VolumeBtn");
            anim.SetBool("VolumeBtn", !Btn);*/
        }
        private  bool IsBgmMute()
        {
            audiomixer.GetFloat("BGM", out float bgmVoluem);
            return bgmVoluem <= -80f;


            /*bool Btn = anim.GetBool("VolumeBtn");
            anim.SetBool("VolumeBtn", !Btn);*/
        }
        private void SetBgmMute(bool isMute)
        {
            audiomixer.SetFloat("BGM", isMute ? -80f : 0f);

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
                Debug.Log(_name + " 사운드가 SoundManager에 등록되지 않았습니다.");
            }
        }

        public void StopBGM()
        {
            audioSourceBGM.Stop();
        }
    }
}
