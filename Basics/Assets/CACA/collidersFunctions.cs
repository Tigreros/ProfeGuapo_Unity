using UnityEngine;

public class collidersFunctions : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //print("ASDFDSAFdsaf");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CC_Move>().isDash == true)
        {
            Destroy(gameObject);
        }
    }
}
