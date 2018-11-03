using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_platformHolder;

    [HideInInspector]
    public GameObject[,] m_platformGroups;
    private int m_platformGroupSize;

    //private int[] m_randomNumbers;

    List<int> m_randomNumbers = new List<int>();

    private void Start()
    {
        m_platformGroupSize = m_platformHolder[0].transform.childCount;
        m_platformGroups = new GameObject[m_platformHolder.Length,m_platformGroupSize];
        m_randomNumbers = new List<int>();

        GenerateUniqueRandomNumber();

        for (int i = 0; i < m_platformHolder.Length; i++)
        {
            AssignPlatformGroupToArray(i);
        }

        for (int i = 0; i < m_platformHolder.Length; i++)
        {
            for (int z = 0; z < m_platformGroupSize; z++)
            {
                m_randomNumbers[z] = 99;
            }
            ResetUniqueRandomNumber();
            PlacePlatformGroupRandomly(i);
        }
    }

    private void Update()
    {
        ReshufflePlatformPositionWhenClicked(0);
        ReshufflePlatformPositionWhenClicked(1);
    }

    private void ReshufflePlatformPositionWhenClicked(int i)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int z = 0; z < m_platformGroupSize; z++)
            {
                m_randomNumbers[z] = 99;
            }
            ResetUniqueRandomNumber();
            PlacePlatformGroupRandomly(i);
        }
    }

    public void ReshufflePlatformPosition(int i)
    {
        for (int z = 0; z < m_platformGroupSize; z++)
        {
            m_randomNumbers[z] = 99;
        }
        ResetUniqueRandomNumber();
        PlacePlatformGroupRandomly(i);
    }

    private void PlacePlatformGroupRandomly(int i)
    {
        for (int j = 0; j < m_platformGroupSize; j++)
        {
            int k = m_randomNumbers[j];
            m_platformGroups[i,k].transform.localPosition = Vector3.zero;
            m_platformGroups[i,k].SetActive(true);
            m_platformGroups[i,k].transform.Translate(Vector3.up * j);
        }
    }

    private void AssignPlatformGroupToArray(int i)
    {
        for (int y = 0; y < m_platformGroupSize; y++)
        {
            m_platformGroups[i,y] = m_platformHolder[i].transform.GetChild(y).gameObject;
        }
    }

    private void GenerateUniqueRandomNumber()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            m_randomNumbers.Add(UniqueRandomInt(m_platformGroupSize));
        }
    }

    private void ResetUniqueRandomNumber()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            m_randomNumbers[i] = UniqueRandomInt(m_platformGroupSize);
        }
    }

    private int UniqueRandomInt(int max)
    {
        int val = Random.Range(0, max);
        while (m_randomNumbers.Contains(val))
        {
            val = Random.Range(0, max);
        }
        return val;
    }

    private void UniqueRandomNumberGenerator()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            m_randomNumbers[i] = 20;
        }

        for (int i = 0; i < m_platformGroupSize; i++)
        {
            bool isNumberAlreadySelected = false;
            int randomNumber;
            do
            {
                randomNumber = (int)Mathf.Floor(Random.Range(0, 14));
                Debug.Log(randomNumber);

                for (int y = 0; y < m_platformGroupSize; y++)
                {
                    if (m_randomNumbers[y] == randomNumber)
                    {
                        isNumberAlreadySelected = true;
                        break;
                    }
                }
            } while (!isNumberAlreadySelected);

            Debug.Log(randomNumber);
            m_randomNumbers[i] = randomNumber;
        }
    }
}
