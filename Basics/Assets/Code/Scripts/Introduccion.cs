using UnityEngine;
using UnityEngine.Rendering;

public class Introduccion : MonoBehaviour
{

    int vida = 29; // CamelCase
    int daño = 30; // CamelCase
    float velocidadEnvejecimientoProfeGuapo = 5.2f; // Recordar colocar la "f"
    bool meHanGolpeado = false; // Esta es la variable más optima de la muerte
    string cadenaDeCaracteres = "Profe es muy guapo"; // concatenación o lista o array de carácteres
    char carater = 'A';

    int amountBullet = 50;

    // int vida = 29; // PascalCase


    //int TomarPocion()
    //{
    //    return vida = vida + pocion;
    //}

    //void MethodString()
    //{
    //    Debug.Log(cadenaDeCaracteres + "HOLA");
    //}

    //int SumaDeValores(int a, int b)
    //{
    //    return a + b;
    //}


    // se ejecuta antes del start
    void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Esta función solo se llama una vez, en el primer frame del juego
    void Start()
    {
        // operadores lógicos
        //vida = vida + 9;

        // String = string + int por defecto convierte el int en int.ToString();
        //cadenaDeCaracteres = cadenaDeCaracteres + vida;

        // Concatenación de un mensaje
        //print(vida + " " + cadenaDeCaracteres);

        //Debug.Log(cadenaDeCaracteres);

        // Operadores (+, -, /, *, %)

        //if(vida == 34)
        //{
        //    Debug.Log("El profe es verdaderamente guapo");
        //}
        //else
        //{
        //    Debug.Log("El profe no es guapo");
        //}

        //if (vida != 34)
        //{
        //    Debug.Log("El profe es verdaderamente guapo");
        //}
        //else
        //{
        //    Debug.Log("El profe no es guapo");
        //}

        //if (vida <= 34)
        //{
        //    if (vida > 0)
        //    {
        //        Debug.Log("Lanzando animacion de herido");
        //    }
        //    else
        //    {
        //        Debug.Log("El personaje ha muerto");
        //    }
        //}
        //else
        //{
        //    Debug.Log("El profe no es guapo");
        //}

        //if (vida <= 34 && vida > 0) // edad entre 34 y 1, entonces nos devuelve verdad
        //{
        //    Debug.Log("Lanzando profe guapo");
        //}

        //if (vida <= 34 || meHanGolpeado == true) // edad entre 34 y 1, entonces nos devuelve verdad
        //{
        //    Debug.Log("Lanzando animacion de herido");
        //}

        //if (vida > 20)
        //{
        //    Debug.Log("Estoy sanote");
        //}
        //else if (vida <= 20 && vida >= 1)
        //{
        //    Debug.Log("Estoy con poca vida");
        //}
        //else
        //{
        //    Debug.Log("Estoy muerto");
        //}

        // for(numero por el comenzamos; condición para ejecutar bucle ; factor de crecimiento)

        //for (int i = 1; i <= 10; i = i + 1)
        //{
        //    Debug.Log("He utilizado " + i + "Balas, me quedan " + (amountBullet - i) );
        //}

        /*while (vida > 0)
        {
            Debug.Log("Estoy vivo");
        }*/


        //TomarPocion();
        //print(DañoCausadoAtaque(vida,daño,false));
        CargaJuego();
    }

    int DañoCausadoAtaque(int a, int b, bool dañoCritico)
    {
        if (dañoCritico)
        {
            b = b * 2;
        }

        return a - b;
    }

    void CargaJuego()
    {
        int progreso = 0;

        while (progreso <= 100)
        {
            Debug.Log("Cargando... " + progreso + "%");
            progreso++;
        }

        Debug.Log("Carga completa. Bienvenuto!");
    }
}