using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CoreManager : MonoBehaviour
{
    public static event Action<int> OnHealthChanged;
    public static event Action OnCoreDestroyed;

    [SerializeField] private int coreHealth = 100;
    [SerializeField] private float surviveTime = 120f;
    
    private float timer;
    private bool gameEnded = false;

    private void Update()
    {
        if (gameEnded) return;

        timer += Time.deltaTime;
        if (timer >= surviveTime)
        {
            WinGame();
        }
    }

    public void TakeDamage(int damage)
    {
        if (gameEnded) return;

        coreHealth -= damage;
        Debug.Log("[CORE DIRECT] Health: " + coreHealth);
        
        OnHealthChanged?.Invoke(coreHealth);
        
        if (coreHealth <= 0)
        {
            LoseGame();
        }
    }

    private void WinGame()
    {
        gameEnded = true;
        Debug.Log("VICTORY! Core successfully defended for 2 minutes.");
        Time.timeScale = 0;
    }

    private void LoseGame()
    {
        gameEnded = true;
        Debug.Log("CRITICAL ALERT: Core breached! Destroying core and restarting system...");
        
        OnCoreDestroyed?.Invoke();
        
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null) sr.enabled = false;

        ObjectPool pool = FindFirstObjectByType<ObjectPool>();
        Enemy[] activeEnemies = FindObjectsByType<Enemy>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);
        
        foreach (Enemy enemy in activeEnemies)
        {
            if (pool != null)
            {
                pool.Despawn(enemy.gameObject);
            }
            else
            {
                Destroy(enemy.gameObject);
            }
        }
        
        Invoke(nameof(RestartGame), 2f);
    }

    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            TakeDamage(10);
            
            ObjectPool pool = FindFirstObjectByType<ObjectPool>();
            pool?.Despawn(other.gameObject);
        }
    }

    private void Awake()
    {
        OnHealthChanged = null;
        OnCoreDestroyed = null;
    }
}