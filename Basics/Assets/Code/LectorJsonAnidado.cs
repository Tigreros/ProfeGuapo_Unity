using System.IO;
using UnityEngine;

public class LectorJsonAnidado : MonoBehaviour
{
    public string ruta;
    public string contenido;

    public PersonajeAnidado2 pj;

    [ContextMenu("LecturaArray")]
    void LecturaArray()
    {
        // Definir la ruta al archivo JSON (asegúrate de que el archivo está en la carpeta StreamingAssets)
        ruta = Path.Combine(Application.streamingAssetsPath, "JsonAnidado.json");

        // Comprobar si el archivo existe
        if (File.Exists(ruta))
        {
            // Leer el contenido del archivo JSON
            contenido = File.ReadAllText(ruta);

            // Deserializar el JSON a un objeto PersonajeAnidado2
            pj = JsonUtility.FromJson<PersonajeAnidado2>(contenido);


            Debug.Log("Nombre: " + pj.nombre);
            Debug.Log("Vida: " + pj.stats.vida.porcentaje + "%");
            Debug.Log("Estado de Vida: " + pj.stats.vida.Estado);
            Debug.Log("Mana: " + pj.stats.mana);
        }
    }
}
