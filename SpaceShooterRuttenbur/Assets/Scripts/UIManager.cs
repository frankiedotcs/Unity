using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene("spaceshooter");
    }
    
	public void QuitGame()
    {
        Application.Quit();
        //use below for testing!
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
