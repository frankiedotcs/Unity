using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    /// <summary>
    /// public variables
    /// </summary>
    /// 
    public Animator settingsButton;

    public void OpenSettings()
    {
        settingsButton.SetBool("SettingsPressed", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("spaceshooter");
    }
    
	public void QuitGame()
    {
        //Application.Quit();
        //use below for testing!
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
