using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealMeat : MonoBehaviour {
    
    private void OnTriggerEnter(Collider collider) {
        if (collider.gameObject.tag == "Player") {
            ItemCollect meat = collider.gameObject.GetComponent<ItemCollect>();
            meat.CollectMeat();

            Destroy(gameObject, 0f);

        }
    }



}
