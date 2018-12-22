using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSoundRouter : MonoBehaviour {

    public AudioClip click;
    public AudioClip click2;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
        
    }

    public void ClickPlay() {
        audioSource.clip = click;
        audioSource.Play();
    }

    public void Click_2Play() {
        audioSource.clip = click2;
        audioSource.Play();
    }

}
