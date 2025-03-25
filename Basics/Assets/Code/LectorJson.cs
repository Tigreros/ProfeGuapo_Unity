using UnityEngine;
using System.IO;

public class LectorJson : MonoBehaviour
{
    public string ruta; 
    public string contenido; 

    [ContextMenu("Lectura")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Lectura()
    {

        ruta = Path.Combine(Application.streamingAssetsPath, "MiPrimerJson.json");
        contenido = File.ReadAllText(ruta);

        Personaje pj = JsonUtility.FromJson<Personaje>(contenido);

        Debug.Log("NombreLector: " + pj.nombre);
        Debug.Log("vidaLector: " + pj.vida);
        Debug.Log("dineroLector: " + pj.dinero);
        Debug.Log("dineroMuchoLector: " + pj.dineroMucho);
    }
}
