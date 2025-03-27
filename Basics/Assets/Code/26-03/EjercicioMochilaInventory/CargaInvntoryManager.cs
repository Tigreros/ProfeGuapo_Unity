using UnityEngine;
using System.IO;
using System;

public class CargaInvntoryManager : MonoBehaviour
{
    public static Action CallIventario;
    public GameObject player;

    private void Start()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoCarga += CargarMochila;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void OnDisable()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoCarga -= CargarMochila;
    }

    [ContextMenu("Cargar Mochila")]
    void CargarMochila()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        string ruta = Path.Combine(Application.persistentDataPath, "Mochila.json");

        if (File.Exists(ruta))
        {
            string contenido = File.ReadAllText(ruta);
            Mochila mochila = JsonUtility.FromJson<Mochila>(contenido);

            int index = 0;

            foreach (var pokePelota in mochila.pokeballs)
            {
                index++;
            }
            player.GetComponent<Inventaro>().pokeballs = new Pokeball[index];
            index = 0;

            foreach (var pokePelota in mochila.pokeballs)
            {
                player.GetComponent<Inventaro>().pokeballs[index] = new Pokeball { nombre = pokePelota.nombre, cantidad = pokePelota.cantidad };
                index++; 
            }
            index = 0;

            foreach (var pokeBaya in mochila.bayas)
            {
                index++;
            }
            player.GetComponent<Inventaro>().bayas = new Baya[index];
            index = 0;

            foreach (var pokeBaya in mochila.bayas)
            {
                player.GetComponent<Inventaro>().bayas[index] = new Baya { nombre = pokeBaya.nombre, cantidad = pokeBaya.cantidad, efecto =  pokeBaya.efecto};
                index++;
            }
            index = 0;


            foreach (var pokeUtil in mochila.utiles)
            {
                index++;
            }
            player.GetComponent<Inventaro>().utiles = new Util[index];
            index = 0;

            foreach (var pokeUtil in mochila.utiles)
            {
                player.GetComponent<Inventaro>().utiles[index] = new Util { nombre = pokeUtil.nombre, cantidad = pokeUtil.cantidad, tipo = pokeUtil.tipo };
                index++;
            }

            CallIventario?.Invoke();
            Debug.Log("Se ha cargado correctamente la mochilla");
        }
        else
        {
            Debug.Log("No existe guardado de inventario");
        }
    }
}
