using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private int bounces;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private bool isPlayers;

    private Rigidbody2D rb;
    private int remainingBounces;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(bulletSpeed * transform.right, ForceMode2D.Impulse);
        remainingBounces = bounces;
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        GameObject hit = collision.gameObject;

        if (hit.CompareTag("Wall"))
        {
            if (remainingBounces == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                remainingBounces--;
            }
        }

        if (hit.CompareTag("Player"))
        {
            if (isPlayers)
            {
                Destroy(gameObject);
            }
            else
            {
                hit.GetComponent<ICanTakeDamage>().GetDamage(damage);
                Destroy(gameObject);
            }
        }

        if (hit.CompareTag("Enemy"))
        {
            hit.GetComponent<ICanTakeDamage>().GetDamage(damage);
            Destroy(gameObject);
        }

        if (hit.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(hit);
        }
    }
}
