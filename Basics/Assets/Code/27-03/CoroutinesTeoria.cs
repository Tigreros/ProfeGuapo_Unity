using System.Collections;
using UnityEngine;

public class CoroutinesTeoria : MonoBehaviour
{
    public int contador;

    // Start is called before the first frame update
    void Start()
    {
        contador = 0;
        StartCoroutine("Mensaje");
    }

    public IEnumerator Mensaje()
    {
        contador++;
       
        if (contador > 5)
        {
            StopCoroutine("Mensaje");
        }
        else
        {
            print("Hola");
            yield return new WaitForSeconds(3);
            StartCoroutine("Mensaje");
        }
    }
}