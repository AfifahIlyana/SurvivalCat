using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSpecial : MonoBehaviour {

    // When enter trigger
    // Call Collect function from player
    // Destroy gameobject

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {
            ItemCollect diamondCollect = other.gameObject.GetComponent<ItemCollect>();
            diamondCollect.CollectDiamondSpecial();

            Destroy(gameObject, 0f);

        }
    }
}
