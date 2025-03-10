using UnityEngine;

public class SideDoor : MonoBehaviour
{
    [SerializeField] private Camera maincam;
    [SerializeField] private Transform leftCamLocation;
    [SerializeField] private Transform rightCamLocation;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            if (transform.position.x > player.transform.position.x)
            {
                maincam.GetComponent<MainCamera>().targetLocation = leftCamLocation;
            }
            else
            {
                maincam.GetComponent<MainCamera>().targetLocation = rightCamLocation;
            }
        }
    }
}
