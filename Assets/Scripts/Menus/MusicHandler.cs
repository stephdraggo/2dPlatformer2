using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [Header("Music")]
    public AudioMixer masterAudio; 
    public Slider musicSlider;
    public Toggle muteToggle;
    
    [Header("Sound Effects")]
    public Slider SFXSlider;
    public AudioSource starPickUpFX;

    private void Start()
    {
        Time.timeScale = 1;
    }
    public void StarFX()
    {
        starPickUpFX.Play(); //Coin sound will play when collected
    }
    public void ChangeVolume(float volume)
    {
        //float volume is the parameter name of the volume on the AudioMixer in Unity
        masterAudio.SetFloat("volume", volume);
    }

    public void SetSFXVolume(float SFXVol)
    {
        masterAudio.SetFloat("SFXVol", SFXVol);
    }

    public void ToggleMute(bool isMuted) //Function to mute volume when toggle is active
    {
        //string reference isMuted connects to the AudioMixer master group Volume and isMuted parameters in Unity
        if (isMuted)
        {
            //-80 is the minimum volume
            masterAudio.SetFloat("isMutedVolume", -80);
        }
        else
        {
            //20 is the maximum volume
            masterAudio.SetFloat("isMutedVolume", 20);
        }
    }
}
