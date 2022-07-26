using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using YG;

public class Music : MonoBehaviour
{
    //ForMusics
    [SerializeField] GameObject MusicOFF;
    [SerializeField] GameObject MusicON;
    public AudioClip[] audioClips; // массив аудио эффектов
    public AudioMixerGroup[] audioGroup; // массив аудио групп
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
        //MusicOFF.SetActive(false);
        //MusicON.SetActive(true);
        //PlaySound((Random.Range(0,20)), (Random.Range(0, 20)));
    }
    public void musicOFF()
    {
        MusicON.SetActive(false);
        MusicOFF.SetActive(true);
        //выкл музыки
        AS.Stop();
        MusicIsOff = true;

        YandexGame.savesData.IsMusic = false;

        //YandexGame.SaveProgress();
    }
    public void musicON()
    {
        MusicON.SetActive(true);
        MusicOFF.SetActive(false);
        PlaySound((Random.Range(0, 20)), (Random.Range(0, 20)));
        MusicIsOff = false;

        YandexGame.savesData.IsMusic = true;

        //YandexGame.SaveProgress();
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
