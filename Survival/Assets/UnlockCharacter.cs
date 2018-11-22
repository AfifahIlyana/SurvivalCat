using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockCharacter : MonoBehaviour {
    
    public GameObject dogLock;
    public GameObject monkeyLock;

    public GameObject dogUnlock;
    public GameObject monkeyUnlock;

    private int playableCharacter;
    
    private void Start() {
        
        playableCharacter = PlayerPrefs.GetInt("Playable", 0);

        Debug.Log(playableCharacter);

        if (playableCharacter == 1) {
            dogLock.SetActive(false);
            dogUnlock.SetActive(true);

        } else if (playableCharacter == 2) {
            dogLock.SetActive(false);
            dogUnlock.SetActive(true);

            monkeyLock.SetActive(false);
            monkeyUnlock.SetActive(true);
            
        }
    }


}
