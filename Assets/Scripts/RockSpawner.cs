using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RockSpawner : MonoBehaviour
{
    public static RockSpawner instance;
    public Vector3[] l_positions;
    public int nbOfRocks;

    [SerializeField]
    private GameObject m_rock;

    [SerializeField]
    private float m_planetRadius;

    [SerializeField]
    private uint m_limit;

    [SerializeField]
    private float m_areaDistribution;

    private uint InstanceLimit
    {
        get => m_limit;
        set
        {
            m_limit = value;
            float l_area = 4 * Mathf.PI * m_planetRadius * m_planetRadius;
            m_areaDistribution = l_area / m_limit;
        }
    }


    private void OnValidate()
    {
        this.InstanceLimit = m_limit;
    }

    private void Start()
    {
        this.CreateRocks();

        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            Debug.Log("RockSpawner instance initialized " + instance);
        }

    }

    public void CreateRocks()
    {
        this.ClearRocks();

        l_positions = this.GenerateUniformPositions();
        Debug.Log($"Nb rocks {l_positions.Length}");
        nbOfRocks = l_positions.Length;

        foreach (Vector3 l_position in l_positions)
        {
            this.SpawnRock(this.gameObject, l_position);
        }
    }

    private Vector3[] GeneratePositions()
    {
        List<Vector3> l_positions = new List<Vector3>();
        for (int l_index = 0; l_index < this.InstanceLimit; l_index++)
        {
            Vector3 l_current = UnityEngine.Random.onUnitSphere * m_planetRadius;
            l_positions.Add(l_current);
        }

        return l_positions.ToArray();
    }

    private Vector3[] GenerateUniformPositions()
    {
        List<Vector3> l_positions = new List<Vector3>();
        uint l_limit = this.InstanceLimit * this.InstanceLimit;
        while (l_positions.Count < this.InstanceLimit && l_limit > 0)
        {
            Vector3 l_current = UnityEngine.Random.onUnitSphere * m_planetRadius;
            if (l_positions.All(p_selected => Vector3.SqrMagnitude(l_current - p_selected) > m_areaDistribution))
            {
                l_positions.Add(l_current);
            }
            else
            {
                l_limit--;
            }
        }

        return l_positions.ToArray();
    }

    private void ClearRocks()
    {
        foreach (Transform l_child in this.transform)
        {
            UnityEngine.Object.Destroy(l_child.gameObject);
        }
    }

    private void SpawnRock(GameObject p_parent, Vector3 p_position)
    {
        Quaternion l_orientation = Quaternion.LookRotation(p_position, Vector3.up);
        UnityEngine.Object.Instantiate(m_rock, p_position, l_orientation, p_parent.transform);
    }
}
