using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_platformHolder;

    private int m_platformGroupSize = 15;
    private GameObject[] m_platformGroups;

    //private int[] m_randomNumbers;

    List<int> m_randomNumbers = new List<int>();

    private void Start()
    {
        m_platformGroupSize = m_platformHolder.transform.childCount;
        m_platformGroups = new GameObject[m_platformGroupSize];
        m_randomNumbers = new List<int>();

        GenerateUniqueRandomNumber();
        AssignPlatformGroupToArray();
        PlacePlatformGroupRandomly();
    }

    private void PlacePlatformGroupRandomly()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            int j = m_randomNumbers[i];

            m_platformGroups[j].SetActive(true);
            m_platformGroups[j].transform.Translate(Vector3.up * i);
        }
    }

    private void AssignPlatformGroupToArray()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            m_platformGroups[i] = m_platformHolder.transform.GetChild(i).gameObject;
        }
    }

    private void GenerateUniqueRandomNumber()
    {
        for (int i = 0; i < m_platformGroupSize; i++)
        {
            m_randomNumbers.Add(UniqueRandomInt(m_platformGroupSize));
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
