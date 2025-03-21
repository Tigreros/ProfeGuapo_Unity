using UnityEngine;

public class context : MonoBehaviour
{


    [Header("Habilidades")]
    public string[] habilidades;
    public string[] enemigos;

    [Header("numero pa elegir")]
    [Tooltip("Elige un numero del 0 al 3")]
    public int habilidad;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        habilidades = new string[] { "DobleSalto", "Volar", "Nadar", "Escalar" };

        if (habilidad > -1 && habilidad < habilidades.Length)
        {
            //Debug.Log(PintarHabilidad(habilidad));
        }
        else
        {
            Debug.Log("Loco has metido un indice too much");
        }
    }

    /// Add a context menu named "Do Something" in the inspector
    /// of the attached script.
    [ContextMenu("Pintar Habilidad")]
    void DoSomething()
    {
        habilidades = new string[] { "DobleSalto", "Volar", "Nadar", "Escalar" };
        Debug.Log(PintarHabilidad(habilidad));
    }

    [ContextMenu("Generar Enemigos")]
    void DoSomething1()
    {
        enemigos = new string[] { "goblin", "limo", "bat", "boss" };

        for (int i = 0; i < enemigos.Length; i++) 
        {
            Debug.Log(PintarEnemigo(Random.Range(0, enemigos.Length)));
        }
        
    }

    string PintarEnemigo(int enemigoFunction)
    {
        return enemigos[enemigoFunction];
    }

    string PintarHabilidad(int habilidadFunction)
    {
        return habilidades[habilidadFunction];
    }

}