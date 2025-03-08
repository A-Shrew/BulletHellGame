using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, ICanTakeDamage
{
    [SerializeField] private Transform playerLocation;
    public int Health { get; set; } = 100;
    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
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
}

public interface ICanTakeDamage
{
    public int Health { get; set; }
    public void GetDamage(int damage);
}