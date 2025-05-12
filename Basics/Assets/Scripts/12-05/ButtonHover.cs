using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("El puntero est� sobre el bot�n");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("El puntero sal�o");
    }
}
