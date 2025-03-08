using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    [SerializeField] private Transform playerLocation;
    [SerializeField] private Transform camLocation1;
    [SerializeField] private Transform camLocation2;
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    private Vector3 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = camLocation1.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerLocation.position.x >= 10.5f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, camLocation2.position, ref velocity, speed * Time.deltaTime, maxSpeed);
        }
        if(playerLocation.position.x <= 8.5f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, camLocation1.position, ref velocity, speed * Time.deltaTime, maxSpeed);
        }
    }
}
