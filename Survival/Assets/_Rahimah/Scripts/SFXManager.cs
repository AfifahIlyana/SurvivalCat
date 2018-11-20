using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SFXManager : MonoBehaviour {

    SFX_icon image;
    AudioSource playersfx;

    void Update()
    {
        playersfx = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
      
        image = GameObject.FindObjectOfType<SFX_icon>();
        UpdateIconAndVolume();
    }

   public void UpdateIconAndVolume()
    {
      
        if (PlayerPrefs.GetInt("Mutedsfx", 0) == 0)
        {
            playersfx.GetComponent<AudioSource>().volume = 1;
            image.OnToggle();
          
        }
        else
        {
            playersfx.GetComponent<AudioSource>().volume = 0;
            image.OffToggle();
  
        }
    }
}
