using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgMusic;         // 배경 음악을 재생하는 AudioSource 컴포넌트를 참조하는 변수

    public void SetMusicVolume(float volume)
    {
        bgMusic.volume = volume;         // 전달받은 볼륨 값을 배경 음악의 볼륨에 할당
    }
}