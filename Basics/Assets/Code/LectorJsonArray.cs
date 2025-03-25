using System.IO;
using UnityEngine;

public class LectorJsonArray : MonoBehaviour
{
    public string ruta;
    public string contenido;

    [ContextMenu("LecturaArray")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void LecturaArray()
    {
        ruta = Path.Combine(Application.streamingAssetsPath, "enemigos.json");
        
        contenido = File.ReadAllText(ruta);

        ListaEnemigos datos = JsonUtility.FromJson<ListaEnemigos>(contenido);

        foreach (var i in datos.enemigos) 
        {
            Debug.Log(i.nombre +" "+ i.vida);
        }
    }
}

