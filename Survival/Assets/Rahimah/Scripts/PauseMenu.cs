using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour {

    public GameObject PausedMenuUI;
    private bool GameIsPaused = false;

    
   

    public void Resume()
    {
        PausedMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        PausedMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
 
   
}
