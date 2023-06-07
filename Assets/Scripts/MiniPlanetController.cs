using System;
using UnityEngine;

public class MiniPlanetController : MonoBehaviour
{
    [SerializeField]
    private float m_planetRadius;

    private Quaternion m_trajectory;


    private void Start()
    {
        m_trajectory = Quaternion.identity;
    }
}