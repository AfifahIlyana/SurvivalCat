using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchCharacterScript : MonoBehaviour {

    public static SwitchCharacterScript instance;
    public GameObject avatar_1, avatar_2;

    public int whichAvatarIsOn = 1;

    void Awake()
    {
        MakeInstance();
    }
    // Use this for initialization
    void Start () {
        avatar_1.gameObject.SetActive(true);
        avatar_2.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	public void SwitchAvatar()
    {
        switch (whichAvatarIsOn)
        {
            //if the first avatar is on
            case 1:
                //then the second avatar is on now
                whichAvatarIsOn = 2;

                //disable avatar 1 and enable avatar 2
                avatar_1.gameObject.SetActive(false);
                avatar_2.gameObject.SetActive(true);
                break;

            case 2:
                //then the first avatar is on now
                whichAvatarIsOn = 1;

                //disable the second one and enable the first one
                avatar_1.gameObject.SetActive(true);
                avatar_2.gameObject.SetActive(false);
                break;
        }
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void LoadLevel(int level)
    {
     
        SceneManager.LoadScene(level);
      //  SwitchAvatar();
    }
}
