using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour {

   
    public void ToggleSoundfx()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            PlayerPrefs.SetInt("Muted", 1);
        }
        else
        {
            PlayerPrefs.SetInt("Muted", 0);
        }
    }
}
