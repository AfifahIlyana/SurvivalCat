using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

	public Transform Pupil;
	public Transform Player;
	public float EyeRadius = 1f;

    private Vector3 mPupilCenterPos;

	private void Start() {
		mPupilCenterPos = Pupil.position;

    }

	private void Update() {
        LookAtPlayer();
		
	}

    private void LookAtPlayer() {
        Vector3 lookDir = (Player.position - mPupilCenterPos);

        if (lookDir.magnitude > EyeRadius) {
            lookDir = lookDir.normalized * EyeRadius;
        }

        Pupil.position = mPupilCenterPos + lookDir;

    }

}
