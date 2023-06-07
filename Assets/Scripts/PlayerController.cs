using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _rotationSpeed = 15f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(-Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }
}
