using UnityEngine;

public class buclesExe : MonoBehaviour
{

    public int numDado = 5;
    private int numDado1 = 5;
    protected int numDado2 = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 1; i <= 12; i++)
        {
            print(Multiplicacion(i));
            //int multiplicacion = numDado * i;
            //Debug.Log(numDado * i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int Multiplicacion(int iteracion)
    {
        return numDado * iteracion;
    }

}
