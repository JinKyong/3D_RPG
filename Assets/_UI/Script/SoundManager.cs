using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource bgMusic;         // ��� ������ ����ϴ� AudioSource ������Ʈ�� �����ϴ� ����

    public void SetMusicVolume(float volume)
    {
        bgMusic.volume = volume;         // ���޹��� ���� ���� ��� ������ ������ �Ҵ�
    }
}