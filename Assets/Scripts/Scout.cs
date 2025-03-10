using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, ICanTakeDamage
{
    [SerializeField] private Transform playerLocation;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private float hitCooldown;
    public int Health { get; set; } = 100;
    private Rigidbody2D rb;
    private bool canMove;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    public void GetDamage(int damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Debug.Log(gameObject.name + " died.");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        GameObject hit = collision.gameObject;
        if (hit.CompareTag("Player"))
        {
            if (canMove) 
            {
                hit.GetComponent<ICanTakeDamage>().GetDamage(damage);
                StartCoroutine(HitDelay());
            } 
        }
    }
    private IEnumerator HitDelay()
    {
        canMove = false;
        yield return new WaitForSeconds(hitCooldown);
        canMove = true;
    }
}

public interface ICanTakeDamage
{
    public int Health { get; set; }
    public void GetDamage(int damage);
}