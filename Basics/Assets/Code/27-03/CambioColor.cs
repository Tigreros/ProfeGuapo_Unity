using System.Collections;
using UnityEngine;

public class CambioColor : MonoBehaviour
{

    Renderer rend;

    public Color color1 = Color.white;
    public Color color2 = Color.red;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("CambioColorObj");
    }

    public IEnumerator CambioColorObj()
    {
        Change(color1);
        yield return new WaitForSeconds(2);
        Change(color2);
        yield return new WaitForSeconds(5);
        StartCoroutine("CambioColorObj");
    }

    Color Change(Color color)
    {
        return rend.material.color = color;
    }
}