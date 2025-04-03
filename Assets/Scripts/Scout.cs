using Assets.Scripts;
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
        if (canMove && playerLocation!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
            Look();
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    private void Look()
    {
        Vector3 direction = playerLocation.position - transform.position;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
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