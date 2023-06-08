using UnityEngine;

public class RockColorizer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerENTER detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerEXIT detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
