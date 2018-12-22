using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFX_icon : MonoBehaviour {

    public Image sfxToggleButton;
    public Sprite[] offOnbutton;

    public void OnToggle()
    {
        sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[0];
    }

    public void OffToggle()
    {
        sfxToggleButton.GetComponent<Image>().sprite = offOnbutton[1];
    }

}
