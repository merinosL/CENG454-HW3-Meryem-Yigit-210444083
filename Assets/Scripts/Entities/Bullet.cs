using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;

    private ObjectPool _poolRef;

    private void Start()
    {
        _poolRef = FindFirstObjectByType<ObjectPool>();

        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        Vector3 moveDir = Vector3.right;

        transform.position += moveDir * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D hitObj)
    {
        Enemy hitEnemy = hitObj.GetComponent<Enemy>();

        if (hitEnemy != null)
        {
            if (_poolRef != null)
            {
                _poolRef.Despawn(hitObj.gameObject);
            }

            Destroy(gameObject);
        }
    }
}