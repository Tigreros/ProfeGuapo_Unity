using System.IO;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    private void Start()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoGuardado += Save;
    }

    public void OnDisable()
    {
        GuardadoCargaDatosPersonaje.OnBotonPresionadoGuardado -= Save;
    }

    [ContextMenu("Guardar Datos")]
    void Save()
    {

    Mochila mochila = new Mochila();

        mochila.pokeballs = new Pokeball[]
        {
            new Pokeball
            {
                nombre = "Pokeball",
                cantidad = 20
            },
            new Pokeball
            {
                nombre = "Ultraball",
                cantidad = 10
            }
        };

        mochila.bayas = new Baya[]
        {
            new Baya
            {
                nombre = "Aranaja",
                efecto = "+ 10 Ps",
                cantidad = 5
            },
            new Baya
            {
                nombre = "Zidra",
                efecto = "+ 50 Ps",
                cantidad = 20
            },
            new Baya
            {
                nombre = "Bayamarga",
                efecto = "cura confusión",
                cantidad = 10
            }
        };

        mochila.utiles = new Util[]
        {
            new Util
            {
                nombre = "Pocion",
                tipo = "normal",
                cantidad = 15
            },
            new Util
            {
                nombre = "MT40",
                tipo = "Cabezazo",
                cantidad = 3
            },
            new Util
            {
                nombre = "Cuerda Huida",
                tipo = "Te saca de la cueva",
                cantidad = 105
            }
        };



        string ruta = Path.Combine(Application.persistentDataPath, "Mochila.json");
        string json = JsonUtility.ToJson(mochila, true);

        File.WriteAllText(ruta, json);

        Debug.Log("Se han guardao correctamete lo datos");
    }
}
