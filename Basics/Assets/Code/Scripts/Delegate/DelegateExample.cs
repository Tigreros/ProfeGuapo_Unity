using UnityEngine;

public class DelegateExample : MonoBehaviour
{

    public enum Dificultad { Facil, Normal, Dificil}
    public Dificultad dificultadSeleccionada = Dificultad.Facil;

    public delegate void MensajeInicio();
    MensajeInicio mensajeDelegate;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(dificultadSeleccionada == Dificultad.Facil)
        {
            mensajeDelegate = MensajeFacil;
        }
        if (dificultadSeleccionada == Dificultad.Normal)
        {
            mensajeDelegate = MensajeNormal;
        }
        if (dificultadSeleccionada == Dificultad.Dificil)
        {
            mensajeDelegate = MensajeDificil;
        }

        mensajeDelegate();
    }

    void MensajeFacil()
    {
        Debug.Log("Modo Fácil activado");
    }
    void MensajeNormal(){
        //Debug.Log("Modo Normal activado");
    }
    void MensajeDificil()
    {
        Debug.Log("Modo Dificil activado");
    }

}
