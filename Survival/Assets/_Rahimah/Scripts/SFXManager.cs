using UnityEngine.UI;
using UnityEngine;

public class SFXManager : MonoBehaviour {

    public Image sfxToggleButton;
    public Sprite[] offOnbutton;
    private SFX sound;

    void Start()
    {
        sound = GameObject.FindObjectOfType<SFX>();
        UpdateIconAndVolumes();
    }

    public void Pausesfx()
    {
        sound.ToggleSoundfx();
        UpdateIconAndVolumes();
    }

    void UpdateIconAndVolumes()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            sound.GetComponent<AudioSource>().volume = 1;
            sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[0];
        }
        else
        {
            sound.GetComponent<AudioSource>().volume = 0;
            sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[1];
        }
    }
}
