using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class adsf : MonoBehaviour
{


    public int a = 0, b = 3;


    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1)) 

        //    VisualFeedBackManager.instanceVisuals.ShowDamageffect(transform);
        //    VisualFeedBackManager.instanceVisuals.ShowStatusEffect(transform, StatusEffectType.Burn);

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            VisualFeedBackManager.instanceVisuals.ShowDamageffect(transform);
            VisualFeedBackManager.instanceVisuals.ShowStatusEffect(transform, StatusEffectType.Poison);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            VisualFeedBackManager.instanceVisuals.ShowDamageffect(transform);
            VisualFeedBackManager.instanceVisuals.ShowStatusEffect(transform, StatusEffectType.stunned);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            VisualFeedBackManager.instanceVisuals.ShowDamageffect(transform);
            VisualFeedBackManager.instanceVisuals.ShowStatusEffect(transform, StatusEffectType.Freeze);
        }
    }
}
