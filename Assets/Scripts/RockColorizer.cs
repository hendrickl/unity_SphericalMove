using UnityEngine;

public class RockColorizer : MonoBehaviour
{
    [SerializeField]
    private GameObject _player;

    private void Start()
    {
        _player = GameObject.Find("Player");
    }

    void Update()
    {
        if (transform.position.x > _player.transform.position.x)
        {
            GetComponent<Renderer>().material.color = Color.white;
            Debug.Log("White");
        }
        else if (transform.position.x < _player.transform.position.x)
        {
            GetComponent<Renderer>().material.color = Color.black;
            Debug.Log("Black");
        }
    }
}
