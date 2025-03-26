using System.IO;
using UnityEngine;

public class CargaDatosPersonaje : MonoBehaviour
{
    public string ruta;
    public string contenido;

    PersonajeData personajeData;

    private void Start()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoCarga += Lectura;
    }

    [ContextMenu("Lectura")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Lectura()
    {
        personajeData = GameObject.FindGameObjectWithTag("Player").GetComponent<PersonajeData>();

        print(personajeData.PJname);

        ruta = Path.Combine(Application.persistentDataPath, personajeData.PJname + "Datos.json");
        contenido = File.ReadAllText(ruta);

        PersonajeDatos pj = JsonUtility.FromJson<PersonajeDatos>(contenido);

        personajeData.name = pj.nombre;
        personajeData.life = pj.vida;
        personajeData.experience = pj.experiencia;
        personajeData.level = pj.nivel;

        print("Se han cargado los datos aparentemente");
    }
}

