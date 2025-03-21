using System;
using UnityEngine;
using UnityEngine.UI;

public class BotonDelegado : MonoBehaviour
{
    public Button boton;
    public static Action OnBotonPresionado;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boton = GetComponent<Button>();

        boton.onClick.AddListener(() =>
        {
            //Debug.Log("Botón ha sido presionado");
            OnBotonPresionado?.Invoke();
        });
    }
}
