using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{
    
    public AudioMixer masterAudio;

    
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

    //Function for changing the volume settings in Options Menu (when we put music into the game)
   
}
