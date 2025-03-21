using UnityEngine;

public class asdfadf : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1 * Time.deltaTime * 1.5f, 0, 0));
    }
}
