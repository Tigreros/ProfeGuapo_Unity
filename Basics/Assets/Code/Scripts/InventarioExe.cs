using UnityEngine;

public class InventarioExe : MonoBehaviour
{

    string[] inventario;
    string[] habilidades;
    public int habilidad;



    [ContextMenu("Pintar Habilidad")]
    public void PintarHabilidad(int habilidadFunction)
    {
        Debug.Log(habilidades[habilidadFunction]);
    }


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

    // Update is called once per frame
    void Update()
    {
        
    }



    string PintarInventario()
    {
        for (int i = 0; i < inventario.Length; i++)
        {
            Debug.Log(inventario[i]);
        }

        return "Este es mi inventario";
    }
}
