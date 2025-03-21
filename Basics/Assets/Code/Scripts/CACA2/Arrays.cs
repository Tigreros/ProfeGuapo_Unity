using System;
using UnityEngine;

public class Arrays : MonoBehaviour
{
    //public int numeroDado;

    public string palabra1;
    public string palabra2;

    public char[] letrasPalabra1;
    public char[] letrasPalabra2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (IsAnagrama(palabra1, palabra2))
        {
            Debug.Log("Las dos palabras son anagramas");
        }
        else
        {
            Debug.Log("Las dos palabras NO son anagramas");
        }
    }

    bool IsAnagrama(string palabra1, string palabra2)
    {
        palabra1 = palabra1.ToLower();
        palabra2 = palabra2.ToLower();

        letrasPalabra1 = palabra1.ToCharArray();
        letrasPalabra2 = palabra2.ToCharArray();

        Array.Sort(letrasPalabra1);
        Array.Sort(letrasPalabra2);

        for (int i = 0; i < letrasPalabra1.Length; i++)
        {
            if (letrasPalabra1[i] != letrasPalabra2[i])
            {
                return false;
            }
        }
        return true;

        /*
        if (letrasPalabra1 == letrasPalabra2)
        {
            return true;
        }
        else
        {
            return false;
        }*/


        //if (palabra1.Length != palabra2.Length)
        //{
        //    return false;
        //}

        //for (int i = 0; i < palabra1.Length; i++)
        //{
        //    bool encontrada = false;

        //    for (int j = 0; j < palabra2.Length; j++)
        //    {
        //        if (palabra1[i] == letrasPalabra2[j])
        //        {
        //            print(j);
        //            letrasPalabra2[j] = '*';
        //            encontrada = true;
        //            break;
        //        }
        //    }
        //    if (encontrada == false) 
        //    {
        //        return false;
        //    }
        //}

        //return true;

    }











































    /*bool isPalindroma(string palabra)
    {
        palabra = palabra.ToUpper().Replace(" ", "");

        for (int i = 0; i < palabra.Length / 2; i++)
        {
            if (palabra[i] != palabra[palabra.Length - 1 - i])
            {
                return false;
            }
        }
        return true;
    }*/















    //int Factorial(int numeroDadoFunction)
    //{
    //    int sumatoria = 1;
    //    for (int i = numeroDado; i > 0; i--)
    //    {
    //        sumatoria = sumatoria * (i);
    //    }

    //    return sumatoria;
    //}

    //int Factorial1(int numeroDadoFunction)
    //{
    //    int sumatoria = 1;
    //    for (int i = 1; i < numeroDado; i++)
    //    {
    //        sumatoria = sumatoria * (i + 1);
    //    }

    //    return sumatoria;
    //}







    // Bucle que busca si la palabra introducida contiene el caracter a
    //for (int i = 0; i < nombre.Length; i++)
    //{
    //    if (nombre[i] == 'a')
    //    {
    //        //print("El nombre dado contiene la letra A");
    //        break;
    //    }
    //}


    // declaracion de array en Start()
    //numeros = new int[] { 8, 54, 32, 7, 78 };
    ////print(numeros[3]);


    //// Busca en el array si se encuentra un valor igual a 32
    //for (int i = 0; i < numeros.Length; i++)
    //{
    //    if (numeros[i] == 32)
    //    {
    //        //print("El numero " + 32 + "se encuentra en la posicion:" + (i + 1));
    //        break;
    //    }
    //    //print("En el indice: " + i + "Esta el valor: " + numeros[i]);
    //}


    // Update is called once per frame
    void Update()
    {
        
    }
}
