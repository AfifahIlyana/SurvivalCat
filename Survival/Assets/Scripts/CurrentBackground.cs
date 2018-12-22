using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentBackground : MonoBehaviour {
    // 0 - Cave
    // 1 - Ocean
    // 2 - Ground
    // 3 - Forest
    // 4 - Mountain
    // 5 - Sky
    // 6 - Space
    
    private int currentBackground;

    private void Start() {
        currentBackground = 0;
    }

    public void UpdateBackground() {
        currentBackground++;
    }

    public int GetCurrentBackground() {
        return currentBackground;
    }

}
