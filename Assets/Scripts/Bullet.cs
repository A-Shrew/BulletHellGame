using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpeed * transform.right, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.CompareTag("Enemy"))
        {
            hit.GetComponent<ICanTakeDamage>().GetDamage(25);
            Destroy(gameObject);
        }
    }
}
