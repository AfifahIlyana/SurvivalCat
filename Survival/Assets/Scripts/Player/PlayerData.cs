using System.Collections;
using UnityEngine;

public class PlayerData : MonoBehaviour 
{
    [HideInInspector]
    public static bool isPotionActivated = false;

    [HideInInspector]
    public int m_health;
    [HideInInspector]
    public int m_score;
    [HideInInspector]
    public int m_attack;
    [HideInInspector]
    public int m_speed;

    private void Update() {
        if (isPotionActivated == true) {
            StartCoroutine(DeActivatePotion());
        }
    }

    IEnumerator DeActivatePotion() {
        yield return new WaitForSeconds(10f);
        PlayerData.isPotionActivated = false;
    }

}
