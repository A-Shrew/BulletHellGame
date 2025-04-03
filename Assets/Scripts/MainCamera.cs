using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private float offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = new Vector3(player.position.x,player.position.y,player.position.z-offset);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(player.position.x, player.position.y, player.position.z - offset), speed * Time.deltaTime);
    }
}
