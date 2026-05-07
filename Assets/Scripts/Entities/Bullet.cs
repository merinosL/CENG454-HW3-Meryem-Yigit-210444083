using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            ObjectPool pool = FindFirstObjectByType<ObjectPool>();
            pool?.Despawn(other.gameObject);
            Destroy(gameObject);
        }
    }
}