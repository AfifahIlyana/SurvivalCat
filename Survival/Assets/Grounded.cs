using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour {

    public bool grounded = true;

    private void OnTriggerEnter() {
        grounded = true;

    }

}
