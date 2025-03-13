using System.Threading;
using UnityEngine;

public class Patrulla : MonoBehaviour
{

    public Vector3[] waypoints;
    public float timeCount;
    public int i;
    public float proximity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        i = 0;
        timeCount = 0.001f;
    }

    private void Update()
    {
        //Tener un movimiento acelerado 
        //timeCount = (timeCount + Time.deltaTime * 0.01f);
        transform.position = Vector3.Lerp(transform.position, waypoints[i], timeCount);

        if(Vector3.Distance(waypoints[i], transform.position) < proximity)
        {
            i++;

            if (i % 2 == 0)
            {
                timeCount = 0.001f;
            }
            else 
            {
                timeCount = 0.01f;
            }

            if(i >= waypoints.Length)
            {
                i = 0;
            }
        }
    }
}
