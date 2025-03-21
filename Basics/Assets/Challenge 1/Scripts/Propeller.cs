using UnityEngine;

public class Propeller : MonoBehaviour
{

    public float rotatePropellerSpeed;
    public GameObject whoIsMyDAD;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        whoIsMyDAD = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotatePropellerSpeed * 10);
    }
}
