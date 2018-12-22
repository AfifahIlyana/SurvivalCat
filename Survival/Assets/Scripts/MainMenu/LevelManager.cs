using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public float autoLoadNextLevelAfter;
    MusicPlayer musicPlayer;
 
    void Start()
    {
        musicPlayer = GameObject.FindObjectOfType<MusicPlayer>();
        if (autoLoadNextLevelAfter <= 0)
        {
            //
        }
        else
        {
            Invoke("LoadNextLevel", autoLoadNextLevelAfter);
        }
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

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }




}
