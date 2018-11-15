using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealPlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_platforms;
    [SerializeField]
    private int m_noOfPlatforms = 1;
    [SerializeField]
    private int m_platformHeightSeparation = 1;
    [SerializeField]
    private float m_noiseScale = 1f;

    void Start ()
    {
        for (int i = 0; i <= m_noOfPlatforms; i++)
        {
            Debug.Log((Mathf.PerlinNoise(1f, (float)i / (float)m_noOfPlatforms) * m_noiseScale) - 100);
            GameObject platform = Instantiate(m_platforms, transform.position, Quaternion.identity);
            if ((Mathf.PerlinNoise(1f, (float)i / (float)m_noOfPlatforms) * m_noiseScale) -100 < -17f)
            {
                platform.transform.Rotate(Vector3.up * 90, Space.Self);
            }
            platform.transform.Translate(new Vector3((Mathf.PerlinNoise(1f, (float)i / (float)m_noOfPlatforms) * m_noiseScale) - 100, 0 + i * m_platformHeightSeparation, -17f), Space.Self);
        }
	}
}
