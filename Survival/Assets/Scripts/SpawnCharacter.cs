using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCharacter : MonoBehaviour {

    public GameObject[] Characters;
    public Transform PlayerSpawnPoint;

	// Use this for initialization
	void Awake () {
        
        Instantiate(Characters[PlayerNum.CharacterNum],PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
    }

}
