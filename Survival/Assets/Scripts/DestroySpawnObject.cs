using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySpawnObject : MonoBehaviour {
    
    public void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Item" || other.gameObject.tag == "Diamond") {
            Destroy(other.gameObject);

        }

    }

}
