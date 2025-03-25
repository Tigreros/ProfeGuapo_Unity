using UnityEngine;
using System.IO;

public class GuardarJson : MonoBehaviour
{

    public string PJname;
    public int level;
    public float life;


    [ContextMenu("SaveData")]
    void SaveData()
    {
        JugadorData datos = new JugadorData();

        datos.nombre = PJname;
        datos.nivel = level;
        datos.vida = life;

        string json = JsonUtility.ToJson(datos, true);

        string ruta = Path.Combine(Application.persistentDataPath, PJname + "Datos.json");

        File.WriteAllText(ruta, json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
