using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void OnEnable()
    {
        CoreManager.OnHealthChanged += UpdateHealthDisplay;
        CoreManager.OnCoreDestroyed += ShowGameOver;
    }

    private void OnDisable()
    {
        CoreManager.OnHealthChanged -= UpdateHealthDisplay;
        CoreManager.OnCoreDestroyed -= ShowGameOver;
    }

    private void UpdateHealthDisplay(int currentHealth)
    {
        Debug.Log("Core Health: " + currentHealth);
    }

    private void ShowGameOver()
    {
        Debug.Log("Game Over! Core Breach!");
    }
}