using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefab;

	// Use this for initialization
	void Start () {

        int i = Random.Range(0, 2);

        foreach(Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab[i], child.transform.position, Quaternion.identity);
            enemy.transform.parent = child;
        }
      
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
