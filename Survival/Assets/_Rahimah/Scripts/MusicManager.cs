using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MusicManager : MonoBehaviour {

    
    
      public Button musicToggleButton;
      public Sprite [] offOnbutton;
      private MusicPlayer music;

    void Start()
    {
        music = GameObject.FindObjectOfType<MusicPlayer>();
        UpdateIconAndVolume();
    } 

    public void PauseMusic()
    {
        music.ToggleSound();
        UpdateIconAndVolume();
    }

    void UpdateIconAndVolume()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            AudioListener.volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = offOnbutton[0];
        }
        else
        {
            AudioListener.volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = offOnbutton[1];
        }
    }

     
}



