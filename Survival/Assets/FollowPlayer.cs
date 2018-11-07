﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void Update() {
        transform.position = player.position;

    }

}
