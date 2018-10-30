using UnityEngine;
using TMPro;

public class MyUIManager : MonoBehaviour 
{
    [SerializeField]
    private GameObject[] m_hearts;
    [SerializeField]
    private TextMeshProUGUI m_currentScore;
    [SerializeField]
    private GameObject plus10;
    [SerializeField]
    private GameObject plus30;

    public void UpdateHealthStatus (int healthLeft, bool heartStatus)
    {
        m_hearts[healthLeft].SetActive(heartStatus);
    }

    public void UpdateScoreStatus(GameObject player)
    {
        m_currentScore.text = player.GetComponent<PlayerData>().m_score.ToString();
    }

    private void AppearAndDestroy(string type)
    {
        GameObject plusScoreText;

        int plusScoreLength = m_currentScore.text.Length - 1;
        float xPos = 20 + (plusScoreLength * 15);

        switch (type)
        {
            case "Normal":
                plusScoreText = Instantiate(plus10, m_currentScore.transform.position, Quaternion.identity);
                plusScoreText.transform.SetParent(m_currentScore.gameObject.transform);

                plusScoreText.transform.localPosition = new Vector3(xPos, -50f, 0f);

                Destroy(plusScoreText, 0.5f);
                break;

            case "Special":
                plusScoreText = Instantiate(plus30, m_currentScore.transform.position, Quaternion.identity);
                plusScoreText.transform.SetParent(m_currentScore.gameObject.transform);

                plusScoreText.transform.localPosition = new Vector3(xPos, -50f, 0f);

                Destroy(plusScoreText, 0.5f);
                break;

        }

    }
}
