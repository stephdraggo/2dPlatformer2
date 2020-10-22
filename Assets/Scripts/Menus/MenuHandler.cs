using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    #region Variables
    public GameObject optionsMenu;
    

    //Variables for changing resolution
    public Resolution[] resolutions;
    public Dropdown resolution;

    #endregion

    #region Functions/Methods
    public void ChangeScene(int sceneIndex) //Function to change from Main Menu scene to the game scene
    {
        SceneManager.LoadScene(sceneIndex);
    }

    
    public void ExitGame() //Function to quit the game
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
        optionsMenu.SetActive(false);

        StartResolution();

    }
    
    //Function that uses int as Index value which will connect to the dropdown element when interacting
     public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void StartResolution()
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

    #endregion

}
