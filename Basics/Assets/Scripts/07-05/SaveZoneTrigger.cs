using UnityEngine;
using UnityEngine.UI;

public class SaveZoneTrigger : MonoBehaviour
{
    public Button button;
    public bool inZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inZone = false;
        }
    }

    public void InSaveZone()
    {
        if (button != null)
        {
            button.interactable = inZone;
        }
    }

}
