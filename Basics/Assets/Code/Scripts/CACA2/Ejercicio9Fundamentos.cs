using UnityEngine;

public class Ejercicio9Fundamentos : MonoBehaviour
{
    int edad = 30;
    string nombre = "El Daniel";
    float precioCostePan = 0.3f;
    float beneficio = 0.2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(nombre + " tiene " + MesesVida() + " meses de vida");
        Debug.Log(MinutosVida());
        Debug.Log(FechaNacimiento());
        Debug.Log(PrecioPanMercadona());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int MesesVida()
    {
        return edad * 12;
    }

    int MinutosVida()
    {
        return (edad * 12) * 43200;
    }

    int FechaNacimiento()
    {
        return 2024 - edad;
    }

    float PrecioPanMercadona()
    {
        return precioCostePan + beneficio;
    }
}
