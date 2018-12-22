using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickAudio : MonoBehaviour {

    public AudioClip clickSound;

    private AudioSource audioSource;

	void Start () {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
	}

    public void ClickSoundPlay() {
        audioSource.clip = clickSound;
        audioSource.Play();
    }
	
	
}
