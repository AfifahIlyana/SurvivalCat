using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    MusicPlayer musicPlayer;
 
    void Start()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
     
    }

	public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
        Time.timeScale = 1;
    }

    public void ResetLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    
    
}
