using Public;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//namespace 

[System.Serializable]
public class Sound  // 컴포넌트 추가 불가능.  MonoBehaviour 상속 안 받아서. 그냥 C# 클래스.
{
    public string name;  // 곡 이름
    public AudioClip clip;  // 곡
}

public class SoundManager : Singleton<SoundManager>
{

    private void Awake()  // 객체 생성시 최초 실행 (그래서 싱글톤을 여기서 생성)
    {
        RegisterInstance();
    }

    [SerializeField] AudioMixer audiomixer;
    [SerializeField] Slider volumeSlider;


    [SerializeField] Sound[] effectSounds;  // 효과음 오디오 클립들
    [SerializeField] Sound[] bgmSounds;  // BGM 오디오 클립들


    [SerializeField] AudioSource audioSourceBFM;  // BGM 재생기. BGM 재생은 한 군데서만 이루어지면 되므로 배열 X 
    [SerializeField] AudioSource[] audioSourceEffects;  // 효과음들은 동시에 여러개가 재생될 수 있으므로 'mp3 재생기'를 배열로 선언

    [SerializeField] string[] playSoundName;  // 재생 중인 효과음 사운드 이름 배열


    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
    }

    public void SetVolume()
    {
        float value = volumeSlider.value;
        audiomixer.SetFloat("BGM", value);
    }

    public void PlaySE(string _name)
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if (_name == effectSounds[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; j++)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        audioSourceEffects[j].clip = effectSounds[i].clip;
                        audioSourceEffects[j].Play();
                        playSoundName[j] = effectSounds[i].name;
                        return;
                    }
                }
                Debug.Log("모든 가용 AudioSource가 사용 중입니다.");
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void PlayBGM(string _name)
    {
        for (int i = 0; i < bgmSounds.Length; i++)
        {
            if (_name == bgmSounds[i].name)
            {
                audioSourceBFM.clip = bgmSounds[i].clip;
                audioSourceBFM.Play();
                return;
            }
        }
        Debug.Log(_name + "사운드가 SoundManager에 등록되지 않았습니다.");
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            audioSourceEffects[i].Stop();
        }
    }

    public void StopSE(string _name)
    {
        for (int i = 0; i < audioSourceEffects.Length; i++)
        {
            if (playSoundName[i] == _name)
            {
                audioSourceEffects[i].Stop();
                break;
            }
        }
        Debug.Log("재생 중인" + _name + "사운드가 없습니다. ");
    }
}
