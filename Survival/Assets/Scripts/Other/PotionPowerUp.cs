using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPowerUp : MonoBehaviour {

    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            ItemCollect potion = collider.gameObject.GetComponent<ItemCollect>();
            potion.CollectPowerUp();

            Destroy(gameObject, 0f);

        }
    }
}
