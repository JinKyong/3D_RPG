using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound  // ������Ʈ �߰� �Ұ���.  MonoBehaviour ��� �� �޾Ƽ�. �׳� C# Ŭ����.
{
    public string name;  // �� �̸�
    public AudioClip clip;  // ��
}

public class SoundManager : MonoBehaviour
{
    #region singleton
    static public SoundManager instance;  // �ڱ� �ڽ��� ���� �ڿ�����. static�� ���� �ٲ� �����ȴ�.

    private void Awake()  // ��ü ������ ���� ���� (�׷��� �̱����� ���⼭ ����)
    {
        if (instance == null)  // �� �ϳ��� �����ϰԲ�
        {
            instance = this;  // ��ü ������ instance�� �ڱ� �ڽ��� �־���
            DontDestroyOnLoad(gameObject);  // �� �ٲ� �� �ڱ� �ڽ� �ı� ����
        }
        else
            Destroy(this.gameObject);
    }
    #endregion singleton


    [SerializeField] Sound[] effectSounds;  // ȿ���� ����� Ŭ����
    [SerializeField] Sound[] bgmSounds;  // BGM ����� Ŭ����


    [SerializeField] AudioSource audioSourceBFM;  // BGM �����. BGM ����� �� �������� �̷������ �ǹǷ� �迭 X 
    [SerializeField] AudioSource[] audioSourceEffects;  // ȿ�������� ���ÿ� �������� ����� �� �����Ƿ� 'mp3 �����'�� �迭�� ����

    [SerializeField] string[] playSoundName;  // ��� ���� ȿ���� ���� �̸� �迭


    void Start()
    {
        playSoundName = new string[audioSourceEffects.Length];
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
                Debug.Log("��� ���� AudioSource�� ��� ���Դϴ�.");
                return;
            }
        }
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
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
        Debug.Log(_name + "���尡 SoundManager�� ��ϵ��� �ʾҽ��ϴ�.");
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
        Debug.Log("��� ����" + _name + "���尡 �����ϴ�. ");
    }
}