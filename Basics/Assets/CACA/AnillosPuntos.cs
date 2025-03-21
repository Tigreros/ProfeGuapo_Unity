using UnityEngine;

public class AnillosPuntos : MonoBehaviour
{
    public int puntos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        BotonDelegado.OnBotonPresionado += LlamadaDeSubscripci�n;
    }

    void LlamadaDeSubscripci�n()
    {
        Debug.Log(gameObject.name);
    } 


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puntos++;

            int getPuntos = PlayerPrefs.GetInt("Puntos");
            puntos = puntos + getPuntos;

            PlayerPrefs.SetInt("Puntos", puntos);
            PlayerPrefs.Save();

            Destroy(gameObject);
        }
    }
}
