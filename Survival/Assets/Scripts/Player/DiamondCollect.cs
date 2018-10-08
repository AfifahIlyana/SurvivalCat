using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollect : MonoBehaviour {

    // To be added under Player's component
    // Must have AudioSource with empty clip

    public AudioClip collectNormal;
    public AudioClip collectSpecial;
    public AudioClip collectMeat;
    public AudioClip collectPowerUp;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void CollectDiamond() {

        // Play Audio
        audioSource.clip = collectNormal;
        audioSource.Play();

        // Add to score
        // Normal Diamond + 10
        SendMessage("DiamondScore");

    }

    public void CollectDiamondSpecial() {
        // Play Audio
        audioSource.clip = collectSpecial;
        audioSource.Play();

        // Special Diamond + 30
        SendMessage("DiamondSpecialScore");

    }

    public void CollectPowerUp() {
        // Invicible for 5 seconds
    }

    public void CollectMeat() {
        // Health + 1
    }

}
