using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private Transform coreTransform;
    [SerializeField] private float spawnInterval = 2f;
    
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemyObj = enemyPool.Spawn(transform.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            IEnemyStrategy strategy = Random.value > 0.5f ? new DirectAttackStrategy() : new PatrolStrategy();
            enemy.Initialize(coreTransform, strategy);
        }
    }
}