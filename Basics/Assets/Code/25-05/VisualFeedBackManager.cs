using System.Collections;
using UnityEngine;

public class VisualFeedBackManager : MonoBehaviour
{
    public static VisualFeedBackManager instanceVisuals { get; private set; }

    public GameObject bloodEffectPrefab;
    public GameObject freezeEffectPrefab;
    public GameObject stunnedEffectPrefab;
    public GameObject burnEffectPrefab;
    public GameObject poisonEffectPrefab;


    private void Awake()
    {
        instanceVisuals = this;
    }

    public void ShowDamageffect(Transform target)
    {
        SkinnedMeshRenderer[] rend = target.GetComponentsInChildren<SkinnedMeshRenderer>();

        if(rend != null)
        {
            StartCoroutine(BlinkColor(rend[0]));
        }

        Instantiate(bloodEffectPrefab, target.position, target.rotation);
    }


    public void ShowStatusEffect(Transform target, StatusEffectType effect)
    {
        GameObject fx = null;

        switch (effect)
        {
            case StatusEffectType.Burn:
                fx = burnEffectPrefab;
                break;

            case StatusEffectType.Poison:
                fx = poisonEffectPrefab;
                break;

            case StatusEffectType.stunned:
                fx = stunnedEffectPrefab;
                break;

            case StatusEffectType.Freeze:
                fx = freezeEffectPrefab;
                break;
        }

        if(fx != null)
        {
            GameObject instancia = Instantiate(fx, target.position, target.rotation, target);
            //instancia.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
        }
    }


    public IEnumerator BlinkColor(SkinnedMeshRenderer rend)
    {
        Color original = rend.material.color;

        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.2f);

        rend.material.color = original;
    }
}
