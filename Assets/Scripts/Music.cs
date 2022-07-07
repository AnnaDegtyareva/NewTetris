using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Music : MonoBehaviour
{
    //ForMusics
    [SerializeField] GameObject MusicOFF;
    [SerializeField] GameObject MusicON;
    public AudioClip[] audioClips; // массив аудио эффектов
    public AudioMixerGroup[] audioGroup; // массив аудио групп
    [SerializeField] AudioSource AS;

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
        //выкл музыки
        AS.Stop();
        
    }
    public void musicON()
    {
        MusicON.SetActive(true);
        MusicOFF.SetActive(false);
        PlaySound((Random.Range(0, 20)), (Random.Range(0, 20)));
    }
    
}
