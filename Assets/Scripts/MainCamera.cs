using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform targetLocation;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;

    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = targetLocation.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetLocation.position, ref velocity, speed * Time.deltaTime, maxSpeed);
    }
}
