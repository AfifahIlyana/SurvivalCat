using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementZ : MonoBehaviour {

    private float rightLimit;
    private float leftLimit;
    private float direction;

    private void Start() {
        rightLimit = transform.position.z + 3;
        leftLimit = transform.position.z - 3;

        // Randomly chooses the direction of the platfrom (-1, 0, 1)
        direction = Random.Range(-1, 2);

        // if -1 the platform move to the left
        // if 0 the platform will not move
        // if 1 the platform will move to the right

    }

    private void Update() {
        if (transform.position.z < leftLimit) {
            MoveRight();

        } else if (transform.position.z > rightLimit) {
            MoveLeft();

        }

        Vector3 movement = Vector3.right * direction * Time.deltaTime;
        transform.Translate(movement);

    }

    private void MoveRight() {
        direction = -1;

    }

    private void MoveLeft() {
        direction = 1;

    }
}
