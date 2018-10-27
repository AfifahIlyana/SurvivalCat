using UnityEngine;

[RequireComponent(typeof(PlatformDestroy))]
[RequireComponent(typeof(PlatformMovement))]
public class PlatformController : MonoBehaviour 
{
    private PlatformMovement m_platformMovement;
    private PlatformDestroy m_platformDestroy;

    private void Start()
    {
        m_platformMovement = GetComponent<PlatformMovement>();
        m_platformDestroy = GetComponent<PlatformDestroy>();
    }
}
