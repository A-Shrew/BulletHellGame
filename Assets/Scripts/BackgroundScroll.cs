using UnityEngine;
public class BackgroundScroll : MonoBehaviour
{
    public float speed;

    [SerializeField] private Renderer background;
    // Update is called once per frame
    void Update()
    {
        background.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
