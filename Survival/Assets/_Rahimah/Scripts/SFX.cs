using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {
    SFXManager sfxmanager;
 


    void Start()
    {
        sfxmanager = GameObject.FindObjectOfType<SFXManager>();
    }

    public void Pausesfx()
    {
        ToggleSoundfx();
        sfxmanager.UpdateIconAndVolume();
    }


    public void ToggleSoundfx()
    {
        if (PlayerPrefs.GetInt("Mutedsfx", 0) == 0)
        {
            PlayerPrefs.SetInt("Mutedsfx", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Mutedsfx", 0);
        }
    }
}
