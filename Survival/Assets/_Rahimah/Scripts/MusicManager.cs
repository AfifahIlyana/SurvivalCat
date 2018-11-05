using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

      public Image musicToggleButton;
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
            music.GetComponent<AudioSource>().volume = 1;
            musicToggleButton.GetComponent<Image>().sprite = offOnbutton[0];
        }
        else
        {
            music.GetComponent<AudioSource>().volume = 0;
            musicToggleButton.GetComponent<Image>().sprite = offOnbutton[1];
        }
    }
}



