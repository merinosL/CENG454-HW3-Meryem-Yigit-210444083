using UnityEngine;

public class Enemy : MonoBehaviour, IPoolable
{
    private IEnemyStrategy currentStrategy;
    private Transform coreTransform;
    [SerializeField] private float moveSpeed = 3f;
    private bool isCoreDestroyed = false;

    public void Initialize(Transform targetCore, IEnemyStrategy strategy)
    {
        coreTransform = targetCore;
        currentStrategy = strategy;
    }

    public void OnSpawn()
    {
        isCoreDestroyed = false;
        CoreManager.OnCoreDestroyed += HandleCoreDestroyed;
    }

    public void OnDespawn()
    {
        CoreManager.OnCoreDestroyed -= HandleCoreDestroyed;
    }

    private void HandleCoreDestroyed()
    {
        isCoreDestroyed = true;
    }

    private void Update()
    {
        if (isCoreDestroyed || coreTransform == null) return;
        currentStrategy?.ExecuteStrategy(transform, coreTransform, moveSpeed);
    }
}