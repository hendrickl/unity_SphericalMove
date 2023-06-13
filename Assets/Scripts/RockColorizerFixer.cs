using UnityEngine;

public class RockColorizerFixer : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("RockColorizerFixer initialized ");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerSTAY detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
