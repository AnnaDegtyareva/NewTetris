using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    //ForMusics
    [SerializeField] GameObject MusicOFF;
    [SerializeField] GameObject MusicON;
    public AudioClip[] audioClips; // ������ ����� ��������
    public AudioMixerGroup[] audioGroup; // ������ ����� �����
    [SerializeField] public AudioSource AS;
    [HideInInspector] public bool MusicIsOff = false;

    public void PlaySound(int soundNum, int soundGroup)
    {
        AS.clip = audioClips[soundNum];
        AS.outputAudioMixerGroup = audioGroup[soundGroup];
        AS.Play();
    }
    void Start()
    {
        //on and off music
        MusicOFF.SetActive(false);
        MusicON.SetActive(true);
        PlaySound((Random.Range(0,20)), (Random.Range(0, 20)));
    }
    public void musicOFF()
    {
        MusicON.SetActive(false);
        MusicOFF.SetActive(true);
        //���� ������
        AS.Stop();
        MusicIsOff = true;
    }
    public void musicON()
    {
        MusicON.SetActive(true);
        MusicOFF.SetActive(false);
        PlaySound((Random.Range(0, 20)), (Random.Range(0, 20)));
        MusicIsOff = false;
    }
    public void PauseMusic(bool isPause)
    {
        if (MusicIsOff)
            return;
        if (isPause)
            AS.Stop();
        else
            AS.Play();
    }
}
