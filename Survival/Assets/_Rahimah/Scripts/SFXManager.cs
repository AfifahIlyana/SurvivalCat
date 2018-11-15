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
    }

    void FixedUpdate()
    {
        playersfx = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        UpdateIconAndVolume();
    }
   
    public void Pausesfx()
    {
        sfx.ToggleSoundfx();
        UpdateIconAndVolume();
    }

    void UpdateIconAndVolume()
    {
        if (PlayerPrefs.GetInt("Mutedsfx", 0) == 0)
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
