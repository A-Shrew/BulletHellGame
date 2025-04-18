using Assets.Scripts;
using System.Collections;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour, ICanTakeDamage
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Slider healthbar;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float stopSpeed;
    [SerializeField] private float dragSpeed;
    public int Health { get; set; } = 100;
    private Rigidbody2D rb;
    private Vector3 mousePosition;
    private bool canShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canShoot = true;
        InitiateInputs();
        healthbar.maxValue = Health;
    }

    void Update()
    {
        // Drag
        rb.linearVelocity = new Vector2(rb.linearVelocity.x / (1 + dragSpeed), rb.linearVelocity.y / (1 + dragSpeed));

        // Max Velocity Clamp
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);

        healthbar.value = Health;
        CheckDeath();
    }

    private void Move(Vector2 direction)
    {
        Vector2 moveDirection = new Vector2(direction.x, direction.y).normalized;
        rb.AddForce(speed * moveDirection);
    }

    private void Look(Vector3 inputPosition)
    {
        mousePosition = mainCamera.ScreenToWorldPoint(inputPosition);
        Vector3 rotation = mousePosition - transform.position;
        float lookRotation = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;  
        transform.rotation = Quaternion.Euler(0,0,lookRotation);
    }
    private void Stop()
    {
        rb.linearVelocity = (rb.linearVelocity / (1 + stopSpeed));
    }

    private void Shoot()
    {
        if (canShoot)
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            StartCoroutine(ShootDelay());
        }
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(0.2f);
        canShoot = true;
    }

    private void InitiateInputs()
    {
        inputManager.OnMove.AddListener(Move);
        inputManager.OnMouseMove.AddListener(Look);
        inputManager.OnSpacePressed.AddListener(Stop);
        inputManager.OnMousePressed.AddListener(Shoot);
    }
    public void GetDamage(int damage)
    {
        Health -= damage;
    }

    private void CheckDeath()
    {
        if (Health <= 0)
        {
            Debug.Log(gameObject.name + " died.");
            Destroy(gameObject);
        }
    }
}

