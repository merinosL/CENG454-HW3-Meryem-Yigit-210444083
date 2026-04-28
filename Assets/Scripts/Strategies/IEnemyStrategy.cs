using UnityEngine;

public interface IEnemyStrategy 
{
    void ExecuteStrategy(Transform enemyTransform, Transform targetCore, float speed);
}