using UnityEngine;

public class ParImpar : MonoBehaviour
{

    public int num;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(isPar());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool isPar()
    {
        if (num % 2 == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
