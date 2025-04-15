using UnityEngine;
using UnityEngine.UI;

public class togglePrefabSlots : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipFlop()
    {
        GetComponent<Toggle>().isOn = !GetComponent<Toggle>().isOn;
    }
}
