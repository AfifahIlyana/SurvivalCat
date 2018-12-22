using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    
    static MusicPlayer instance = null;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }  
    }

    public void ToggleSound()
    {
        if (PlayerPrefs.GetInt("MuteMusic", 0) == 0)
        {
            PlayerPrefs.SetInt("MuteMusic", 1);
        }
        else
        {
            PlayerPrefs.SetInt("MuteMusic", 0);
        }
    }

}
