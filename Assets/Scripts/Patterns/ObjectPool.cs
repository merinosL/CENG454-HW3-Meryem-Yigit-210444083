using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;
    
    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private void CreateNewObject()
    {
        GameObject obj = Instantiate(prefab, transform);
        obj.SetActive(false);
        pool.Enqueue(obj);
    }

    public GameObject Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            CreateNewObject();
        }

        GameObject obj = pool.Dequeue();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.SetActive(true);

        IPoolable poolable = obj.GetComponent<IPoolable>();
        poolable?.OnSpawn();

        return obj;
    }

    public void Despawn(GameObject obj)
    {
        IPoolable poolable = obj.GetComponent<IPoolable>();
        poolable?.OnDespawn();
        
        obj.SetActive(false);
        pool.Enqueue(obj);
    }
}