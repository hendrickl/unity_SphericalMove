using UnityEngine;

public class RockColorizer : MonoBehaviour
{
    public static RockColorizer instance;
    public int numberOfWhiteRocks;
    public int numberOfBlackRocks;

    private void Start()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            Debug.Log("RockColorizer instance initialized " + instance);
        }
    }

    private void Update()
    {
        ComputeNumberOfWhiteRocks();
        ComputeNumberOfBlackRocks();
    }

    // Detects when a rock enters the trigger zone and changes its color to black
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerENTER detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
    }

    // Detects when a rock exits the trigger zone and changes its color to white
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerEXIT detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }

    // Counts the number of white rocks
    public int ComputeNumberOfWhiteRocks()
    {
        numberOfWhiteRocks = 0;

        GameObject[] rocks = GameObject.FindGameObjectsWithTag("ColoredCube");

        foreach (GameObject rock in rocks)
        {
            if (rock.GetComponent<Renderer>().material.color == Color.white)
            {
                numberOfWhiteRocks++;
                Debug.Log("Number of white rocks :" + numberOfWhiteRocks);
            }
        }
        return numberOfWhiteRocks;
    }

    // Counts the number of black rocks
    public int ComputeNumberOfBlackRocks()
    {
        numberOfBlackRocks = 0;
        numberOfBlackRocks = RockSpawner.instance.nbOfRocks - numberOfWhiteRocks;
        Debug.Log("Number of black rocks :" + numberOfBlackRocks);
        return numberOfBlackRocks;
    }
}
