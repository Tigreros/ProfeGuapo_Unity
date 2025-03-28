using UnityEngine;

public class revisarSitengopHijos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gameObject.transform.childCount == 0)
        { 
            Debug.Log("Ya no tengo hijos");
        }*/

        print(transform.childCount);
    }


}
