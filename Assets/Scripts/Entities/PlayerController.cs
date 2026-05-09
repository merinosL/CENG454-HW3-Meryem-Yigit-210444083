using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IWeapon currentWeapon;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 7f;
    
    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        currentWeapon = new BaseWeapon();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            currentWeapon.Fire(transform, bulletPrefab);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            currentWeapon = new RapidFireDecorator(currentWeapon);
            Debug.Log("Weapon Upgraded: Rapid Fire Acquired");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}