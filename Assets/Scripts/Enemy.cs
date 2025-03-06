using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform playerLocation;
    public float health;
    public float speed;
    public float damage;
   

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
}
