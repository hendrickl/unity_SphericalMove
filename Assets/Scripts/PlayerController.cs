using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 23f;

    [SerializeField]
    private float _moveSpeed = 15f;

    private void Update()
    {
        // Rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }

        // Vertical Movement
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(Vector3.zero, transform.right, _moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(Vector3.zero, -transform.right, _moveSpeed * Time.deltaTime);
        }
    }
}
