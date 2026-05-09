using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        CoreManager.OnHealthChanged += HandleHealthChanged;
        CoreManager.OnCoreDestroyed += HandleCoreDestroyed;
    }

    private void OnDestroy()
    {
        CoreManager.OnHealthChanged -= HandleHealthChanged;
        CoreManager.OnCoreDestroyed -= HandleCoreDestroyed;
    }

    private void HandleHealthChanged(int currentHealth)
    {
        Debug.Log("[UI SYSTEM] Current Core Health: " + currentHealth);
    }

    private void HandleCoreDestroyed()
    {
        Debug.Log("[UI SYSTEM] Alert: Core Integrity Compromised!");
    }
}