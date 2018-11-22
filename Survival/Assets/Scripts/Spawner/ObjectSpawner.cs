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

    private int CurrentBackground() {
        if (transform.position.y < 800f)                                        // Cave
            return 0;

        else if (800f <= transform.position.y && transform.position.y < 1600f)  // Ocean
            return 1;

        else if (1600f <= transform.position.y && transform.position.y < 2400)  // Ground
            return 2;

        else if (2400 <= transform.position.y && transform.position.y < 3400)  // Forest
            return 3;

        else if (3400 <= transform.position.y && transform.position.y < 4900)  // Mountain
            return 4;

        else if (4900 <= transform.position.y && transform.position.y < 8500f)  // Sky 
            return 5;

        else                                                                     // Space
            return 6;
        
    }

    
    public void RandomSpawner()
    {
        float rn = Random.Range(0f, 9f);

        if(rn >= 5f)
        {
            //Debug.Log("No spawner");
            return;
        }

        else
        {
            
            rn = Random.Range(0f, 9f);

            if(rn > 3f)
            {

                if (CurrentBackground() == 0) { // Cave; Spider, Snake, Bat
                    SpawnEnemy(0, 3);

                } else if (CurrentBackground() == 1) { // Ocean; Fishman, Piranha, Shark
                    SpawnEnemy(3, 6);

                } else if (CurrentBackground() == 2) { // Ground; Vampire, Ghost, Skeleton
                    SpawnEnemy(6, 9);

                } else if (CurrentBackground() == 3) { // Forest; Boar
                    SpawnEnemy(9, 10);

                } else if (CurrentBackground() == 4) { // Mountain; Vulture
                    SpawnEnemy(10, 11);

                } else if (CurrentBackground() == 5) { // Sky; Vulture, Alien 1
                    SpawnEnemy(11, 12);

                } else if (CurrentBackground() == 6) { // Space; Alien 1, 2, 3
                    SpawnEnemy(11, 14);

                }


            }

            else
            {
                rn = Random.Range(0f, 9f);
                if(rn >= 5f)
                {
                    //+10
                    GameObject item = Instantiate(diamond, transform.position, Quaternion.identity);
                    item.transform.parent = transform;
                }

                else if(rn > 2f)
                {
                    //+30
                    GameObject item = Instantiate(diamondSpecial, transform.position, Quaternion.identity);
                    item.transform.parent = transform;
                }

                else if(rn > 0.5f)
                {
                    //ayam
                    GameObject item = Instantiate(drumstick, transform.position, Quaternion.identity);
                    item.transform.parent = transform;
                }

                else
                {
                    //potion
                    GameObject item = Instantiate(potion, transform.position, Quaternion.identity);
                    item.transform.parent = transform;
                }
            }

        }
    }

    private void SpawnEnemy(int startingIndex, int lastIndex) {
        //for the enemy character 
        int i = Random.Range(startingIndex, lastIndex);

        Vector3 position = transform.position;

        if (i == 7) { // Skeleton
            // Debug.Log("Enemy: " + enemyPrefab[i].name);
            position = new Vector3(transform.position.x, transform.position.y - 1.3f, transform.position.z);
        } else if (i == 8) {
            position = new Vector3(transform.position.x, transform.position.y - 0.14f, transform.position.z);

        } else if (i == 9) { // Boar
            position = new Vector3(transform.position.x, transform.position.y - 0.22f, transform.position.z);
        } else if (i == 11) { // Alien 1
            position = new Vector3(transform.position.x, transform.position.y - 0.78f, transform.position.z);
        } else if (i == 13) {
            position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        }

        foreach (Transform child in transform) {
            
            GameObject enemy = Instantiate(enemyPrefab[i], position, transform.rotation);
            enemy.transform.parent = child;
            
        }

    }

}
