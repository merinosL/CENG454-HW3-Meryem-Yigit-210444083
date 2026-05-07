using System;
using UnityEngine;

public class CoreManager : MonoBehaviour, IDamageable
{
    public static event Action<int> OnHealthChanged;
    public static event Action OnCoreDestroyed;

    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (currentHealth <= 0) return;

        currentHealth -= amount;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnCoreDestroyed?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    if (other.GetComponent<Enemy>() != null)
    {
        TakeDamage(10);
        ObjectPool pool = FindFirstObjectByType<ObjectPool>();
        if (pool != null) 
        {
            pool.Despawn(other.gameObject);
        }
    }
    }
}