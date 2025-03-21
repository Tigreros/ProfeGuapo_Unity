using UnityEngine;

public class Mat : MonoBehaviour
{

    float x;
    public float y;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        x = 10;
    }

    // Update is called once per frame
    void Update()
    {
        x -= Time.deltaTime * 0.1f; 
        y = Mathf.Log(x, 10);
    }
}
