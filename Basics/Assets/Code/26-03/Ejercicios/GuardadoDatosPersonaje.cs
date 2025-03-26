using System.IO;
using UnityEngine;

public class GuardadoDatosPersonaje : MonoBehaviour
{

    PersonajeData personajeData;

    void Start()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoGuardado += SaveData;
        //print("")
    }

    [ContextMenu("SaveData")]
    void SaveData()
    {
        personajeData = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonajeData>();

        PersonajeDatos datos = new PersonajeDatos();

        datos.nombre = personajeData.PJname;
        datos.nivel = personajeData.level;
        datos.vida = personajeData.life;
        datos.experiencia = personajeData.experience;

        string json = JsonUtility.ToJson(datos, true);

        string ruta = Path.Combine(Application.persistentDataPath, personajeData.PJname + "Datos.json");

        File.WriteAllText(ruta, json);

        print("Se han guardado los datos aparentemente");
    }

}
