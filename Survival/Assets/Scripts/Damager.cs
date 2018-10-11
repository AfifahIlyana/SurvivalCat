using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour {
    // Put this script under all damager (enemies and obstacles)
    
    private float timeSinceLastDamage;
    private Health playerHealth;

    // Update is called once per frame
    private void Update() {
        timeSinceLastDamage += Time.deltaTime;

    }

    private void OnTriggerStay(Collider collider) {

        if (collider.tag == "Player") {

            if (timeSinceLastDamage > 1f) {
                
                // Insert here Player taking damage animation

                playerHealth = collider.gameObject.GetComponent<Health>();
                playerHealth.TakeDamage();

                timeSinceLastDamage = 0;

            }
        }
    }

}
