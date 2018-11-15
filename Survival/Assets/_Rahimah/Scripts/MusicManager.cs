using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour {

      public Image musicToggleButton;
      public Sprite [] offOnbutton;
      private GameObject music;

    void Start()
    {
        //music = GameObject.FindObjectOfType<MusicPlayer>();
        music = GameObject.Find("Music");
        UpdateIconAndVolume();
    } 

    public void PauseMusic()
    {
        music.GetComponent<MusicPlayer>().ToggleSound();
        UpdateIconAndVolume();
    }

    void UpdateIconAndVolume()
    {
        if (PlayerPrefs.GetInt("MuteMusic", 0) == 0)
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



