using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite sprite;
    public int damage;
    public StatusEffectType effect;

    public void OnPointerEnter(PointerEventData eventData)
    {
        PanelInformation.instance_PanelInformation.ChangePanelInformation(sprite, damage.ToString(), effect.ToString());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PanelInformation.instance_PanelInformation.ChangePanelInformation(null, null, null);
    }
}
