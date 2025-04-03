using UnityEngine;

public class Switch : MonoBehaviour, ISwitchable
{

    bool stateSwitch = false;

    public void TurnOn()
    {
        if (stateSwitch)
        {
            Debug.Log("Ya estoy encendido loco");
        }
        else
        {

        }
    }

    public void TurnOff()
    {
        if (!stateSwitch)
        {
            Debug.Log("Ya estoy apagado loco");
        }
        else
        {

        }
    }

    public void Toggle()
    {
        if (stateSwitch)
        {
            Debug.Log("Ahora estoy encendido wey");
        }
        else
        {
            Debug.Log("Ahora estoy apagado wey");
        }
        stateSwitch = !stateSwitch;
    }

}
