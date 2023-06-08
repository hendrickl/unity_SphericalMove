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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerENTER detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        ComputeNumberOfWhiteRocks();
        ComputeNumberOfBlackRocks();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColoredCube"))
        {
            Debug.Log("OntriggerEXIT detected");
            other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
        ComputeNumberOfWhiteRocks();
        ComputeNumberOfBlackRocks();
    }

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

    public int ComputeNumberOfBlackRocks()
    {
        numberOfBlackRocks = 0;
        numberOfBlackRocks = RockSpawner.instance.nbOfRocks - numberOfWhiteRocks;
        Debug.Log("Number of black rocks :" + numberOfBlackRocks);
        return numberOfBlackRocks;
    }
}
