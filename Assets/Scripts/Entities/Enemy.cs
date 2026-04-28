using UnityEngine;

public class Enemy : MonoBehaviour
{
    private IEnemyStrategy currentStrategy;
    private Transform coreTransform;
    [SerializeField] private float moveSpeed = 3f;

    private void Awake()
    {
        CoreManager core = FindObjectOfType<CoreManager>();
        if (core != null)
        {
            coreTransform = core.transform;
        }
    }

    public void SetStrategy(IEnemyStrategy newStrategy)
    {
        currentStrategy = newStrategy;
    }

    private void Update()
    {
        currentStrategy?.ExecuteStrategy(transform, coreTransform, moveSpeed);
    }
}