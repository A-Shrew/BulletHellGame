using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new();
    public UnityEvent OnSpacePressed = new();
    public UnityEvent OnMousePressed = new();
    public UnityEvent <Vector3> OnMouseMove = new();

    void Update()
    {
        Vector2 input = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }
        OnMove?.Invoke(input);

        if (Input.GetKey(KeyCode.Space))
        {
            OnSpacePressed?.Invoke();
        }

        if (Input.GetMouseButton(0))
        {
            OnMousePressed?.Invoke();
        }

        OnMouseMove?.Invoke(Input.mousePosition);
    

    }
}
