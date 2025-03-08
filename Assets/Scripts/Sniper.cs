using System.Collections;
using UnityEngine;

public class Sniper : MonoBehaviour, ICanTakeDamage
{
    [SerializeField] private Transform playerLocation;
    public int Health { get; set; } = 50;
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float range;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    private Rigidbody2D rb;
    private bool canShoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Attack();
    }

    private void Attack()
    {
        Vector3 position = transform.position;
        Vector3 target = playerLocation.position;

        float distance = Vector3.Magnitude(target - position);
        if (distance > range)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, speed * Time.deltaTime);
        }
        else
        {
            if (canShoot)
            {
                Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                StartCoroutine(ShootDelay());
            } 
        }
    }

    private void Look()
    {
        Vector3 direction = playerLocation.position - transform.position;
        direction.Normalize();
        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(1f);
        canShoot = true;
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
