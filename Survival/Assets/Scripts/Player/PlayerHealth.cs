using UnityEngine;

public class PlayerHealth : MonoBehaviour 
{
    public void TakeDamage ()
    {
        
    }

    public void AddHealth (int addHealth, GameObject player)
    {
        player.GetComponent<PlayerData>().m_health += addHealth;
    }

    public void ResetHealth (PlayerData playerHealth)
    {
        playerHealth.m_health = 3;
    }
}
