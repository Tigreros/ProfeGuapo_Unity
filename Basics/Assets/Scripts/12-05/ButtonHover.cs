using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("El puntero está sobre el botón");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("El puntero salío");
    }
}
