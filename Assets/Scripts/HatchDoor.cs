using UnityEngine;

public class HatchDoor : MonoBehaviour
{
    [SerializeField] private Camera maincam;
    [SerializeField] private Transform topCamLocation;
    [SerializeField] private Transform bottomCamLocation;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject player = collision.gameObject;
        if (player.CompareTag("Player"))
        {
            if (transform.position.y > player.transform.position.y)
            {
                maincam.GetComponent<MainCamera>().targetLocation = bottomCamLocation;
            }
            else
            {
                maincam.GetComponent<MainCamera>().targetLocation = topCamLocation;
            }
        }
    }
}
