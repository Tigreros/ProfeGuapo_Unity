using System.Collections;
using UnityEngine;

public class CmabioColorProgresivo : MonoBehaviour
{
    Material material;


    public float red;
    public float green;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        material = GetComponent<Renderer>().material;
        red = material.color.r;
        green = material.color.g;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("cambioColorProgresivo");
        }
    }

    IEnumerator cambioColorProgresivo()
    {
        while(red > 0)
        {
            red = red - 0.01f;
            green = green + 0.01f;
            material.color = new Color(red, green, 0);

            yield return new WaitForSeconds(0.05f);
        }

        red = 0;
        green = 1;
    }
}
