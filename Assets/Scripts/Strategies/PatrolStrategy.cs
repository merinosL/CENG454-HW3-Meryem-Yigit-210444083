using UnityEngine;

public class PatrolStrategy : IEnemyStrategy
{
    private float patrolTimer;
    private Vector3 patrolDirection = Vector3.right;

    public void ExecuteStrategy(Transform enemyTransform, Transform targetCore, float speed)
    {
        patrolTimer += Time.deltaTime;
        if (patrolTimer > 2f)
        {
            patrolDirection = -patrolDirection;
            patrolTimer = 0f;
        }
        
        enemyTransform.position += patrolDirection * speed * Time.deltaTime;
    }
}