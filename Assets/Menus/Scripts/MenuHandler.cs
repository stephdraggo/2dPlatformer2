﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;


public class MenuHandler : MonoBehaviour
{
    #region Variables

    public AudioMixer masterAudio;

    //Variables for changing resolution
    public Resolution[] resolutions;
    public Dropdown resolution;

    #endregion

    #region Functions/Methods
    //Function for changing the volume settings in Options Menu (when we put music into the game)
    public void ChangeVolume(float volume)
    {
        //float volume is the parameter name of the volume on the AudioMixer in Unity
        masterAudio.SetFloat("volume", volume);
    }

    //Function to change from Main Menu scene to the game scene
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    //Function to mute volume when toggle is active
    public void ToggleMute(bool isMuted)
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

    //Function to quit the game
    public void ExitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    //Function for changing quality setting in the options menu
    public void ChangeQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //Function for making the game full screen
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    //Start function for setting up the resolution options for the Dropdown in Unity
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolution.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolution.AddOptions(options);
        resolution.value = currentResolutionIndex;
        resolution.RefreshShownValue();
    }
    
    //Function that uses int as Index value which will connect to the dropdown element when interacting
     public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    #endregion

}
