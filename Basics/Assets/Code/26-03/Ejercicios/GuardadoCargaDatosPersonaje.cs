using System;
using UnityEngine;
using UnityEngine.UI;

public class GuardadoCargaDatosPersonaje : MonoBehaviour
{
    public Button botonGuardado;
    public Button botonCarga;

    public bool isSave;

    public static Action OnBotonPresionadoGuardado;
    public static Action OnBotonPresionadoCarga;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isSave)
        {
            botonGuardado = GetComponent<Button>();
            botonGuardado.onClick.AddListener(() =>
            {
                Debug.Log("Botón GUARDADO ha sido presionado");
                OnBotonPresionadoGuardado?.Invoke();
            });

        }
        else
        {
            botonCarga = GetComponent<Button>();
            botonCarga.onClick.AddListener(() =>
            {
                Debug.Log("Botón CARGA ha sido presionado");
                OnBotonPresionadoCarga?.Invoke();
            });
        }
    }
}
