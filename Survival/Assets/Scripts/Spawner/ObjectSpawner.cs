using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    
    public GameObject[] enemyPrefab;
    public GameObject diamond;
    public GameObject diamondSpecial;
    public GameObject drumstick;
    public GameObject potion;

	// Use this for initialization
	void Start () {
        RandomSpawner();
	}

	
	// Update is called once per frame
	void Update () {
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        RandomSpawner();
    //    }
    }

    public void RandomSpawner()
    {
        float rn = Random.Range(0f, 9f);

        if(rn >= 5f)
        {
            Debug.Log("No spawner");
            return;
        }

        else
        {
            rn = Random.Range(0f, 9f);

            if(rn > 3f)
            {
                //for the enemy character 
                int i = Random.Range(0, 3);

                foreach(Transform child in transform)
                {
                    GameObject enemy = Instantiate(enemyPrefab[i], transform.position, Quaternion.identity);
                    enemy.transform.parent = child;
                    Debug.Log("Enemy: " + enemyPrefab[i].name);
                }
            }

            else
            {
                rn = Random.Range(0f, 9f);
                if(rn >= 5f)
                {
                    //+10
                    Instantiate(diamond, transform.position, Quaternion.identity);
                }

                else if(rn > 2f)
                {
                    //+30
                    Instantiate(diamondSpecial, transform.position, Quaternion.identity);
                }

                else if(rn > 0.5f)
                {
                    //ayam
                    Instantiate(drumstick, transform.position, Quaternion.identity);
                }

                else
                {
                    //potion
                    Instantiate(potion, transform.position, Quaternion.identity);
                }
            }

        }
    }
}
