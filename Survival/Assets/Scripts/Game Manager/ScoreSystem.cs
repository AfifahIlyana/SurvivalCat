using UnityEngine;

public class ScoreSystem : MonoBehaviour 
{
    public void HeightScore(float lastHeight, GameObject player)
    {
        int yRounded = Mathf.RoundToInt(player.gameObject.transform.position.y);

        if (yRounded > lastHeight)
        {
            lastHeight++;

            AddScore(1, player);

            //addScore = int.Parse(currentScoreText.text) + 1;
            //currentScoreText.text = addScore.ToString();

        }
    }

    public void AddScore(int addScore, GameObject player)
    {
        player.GetComponent<PlayerData>().m_score += addScore;

        //AppearAndDestroy("Normal");
    }

    public void ResetScore(GameObject player)
    {
        gameObject.GetComponent<MyGameManager>().m_lastHeight = 0;
        player.GetComponent<PlayerData>().m_score = 0;
    }

    //private void AppearAndDestroy(string type)
    //{
    //    GameObject plusScoreText;
    //
    //    int plusScoreLength = currentScoreText.text.Length - 1;
    //    float xPos = 20 + (plusScoreLength * 15);
    //
    //    switch (type)
    //    {
    //        case "Normal":
    //            plusScoreText = Instantiate(plus10, currentScoreText.transform.position, Quaternion.identity);
    //            plusScoreText.transform.SetParent(currentScoreText.gameObject.transform);
    //
    //            plusScoreText.transform.localPosition = new Vector3(xPos, -50f, 0f);
    //
    //            Destroy(plusScoreText, 0.5f);
    //            break;
    //
    //        case "Special":
    //            plusScoreText = Instantiate(plus30, currentScoreText.transform.position, Quaternion.identity);
    //            plusScoreText.transform.SetParent(currentScoreText.gameObject.transform);
    //
    //            plusScoreText.transform.localPosition = new Vector3(xPos, -50f, 0f);
    //
    //            Destroy(plusScoreText, 0.5f);
    //            break;
    //
    //    }
    //
    //}
}
