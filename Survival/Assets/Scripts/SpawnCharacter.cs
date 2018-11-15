using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnCharacter : MonoBehaviour {

    public GameObject[] Characters;
    public Transform PlayerSpawnPoint;

	// Use this for initialization
<<<<<<< HEAD
	void Awake() {
=======
	void Awake () {
>>>>>>> 4a3a53c14717c325fd0ae65648576d491bca49a9
        Instantiate(Characters[PlayerNum.CharacterNum],PlayerSpawnPoint.position, PlayerSpawnPoint.rotation);
    }

}
