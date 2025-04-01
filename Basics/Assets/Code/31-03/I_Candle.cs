using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class I_Candle : MonoBehaviour, IHitable
{
    public void TakeHit()
    {
        Debug.Log("Vela se rompe " + transform.name);
        Destroy(gameObject, 1);
    }
}
