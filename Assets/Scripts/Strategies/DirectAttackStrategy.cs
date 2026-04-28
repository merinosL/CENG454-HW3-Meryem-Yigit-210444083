using UnityEngine;

public class DirectAttackStrategy : IEnemyStrategy
{
    public void ExecuteStrategy(Transform enemyTransform, Transform targetCore, float speed)
    {
        if (targetCore == null) return;
        
        Vector3 direction = (targetCore.position - enemyTransform.position).normalized;
        enemyTransform.position += direction * speed * Time.deltaTime;
    }
}