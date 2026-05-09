using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private ObjectPool enemyPool;
    [SerializeField] private Transform coreTransform;
    [SerializeField] private float spawnInterval = 3f;
    
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
        if (enemyPool == null) return;

        GameObject enemyObj = enemyPool.Spawn(transform.position, Quaternion.identity);
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        
        if (enemy != null)
        {
            IEnemyStrategy strategy = new DirectAttackStrategy();
            enemy.Initialize(coreTransform, strategy);
        }
    }
}