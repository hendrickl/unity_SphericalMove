using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 15f;

    [SerializeField]
    private float _moveSpeed = 1f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(-Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }


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
