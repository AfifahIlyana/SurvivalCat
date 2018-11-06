using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour {

    public Image sfxToggleButton;
    public Sprite[] offOnbutton;
    MyUIManager sfx;
    AudioSource playersfx;

    void Start()
    {
        sfx = GameObject.FindObjectOfType<MyUIManager>();
        playersfx = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        UpdateIconAndVolumes();
    }
   
    public void Pausesfx()
    {
        sfx.ToggleSoundfx();
        UpdateIconAndVolumes();
    }

    void UpdateIconAndVolumes()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            playersfx.GetComponent<AudioSource>().volume = 1;
            sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[0];
        }
        else
        {
            playersfx.GetComponent<AudioSource>().volume = 0;
            sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[1];
        }
    }
}
