using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelInformation : MonoBehaviour
{

    public static PanelInformation instance_PanelInformation
    { get; private set; }

    public Image sprite;
    public TextMeshProUGUI damage;
    public TextMeshProUGUI effect;

    public void Start()
    {
        instance_PanelInformation = this;

        sprite = transform.GetChild(0).GetChild(0).GetComponent<Image>();
        damage = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        effect = transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    public void ChangePanelInformation(Sprite spriteAttack, string damageAttack, string effectAttack)
    {
        sprite.sprite = spriteAttack;
        damage.text = "DMG :" + damageAttack;
        effect.text = "Effect : " + effectAttack;
    }
}
