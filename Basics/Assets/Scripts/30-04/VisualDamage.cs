using TMPro;
using UnityEngine;

public class VisualDamage : MonoBehaviour
{

    public GameObject g_target;
    public float f_damage;
    private Canvas canvas;
    private Animator animator;

    public void Awake()
    {
        canvas = GetComponent<Canvas>();
        animator = GetComponent<Animator>();
        canvas.enabled = false;
    }

    public void VisualDamageFunction(GameObject target, float damage)
    {
        g_target = target;
        f_damage = damage;
        animator.SetTrigger("VisualDamage");

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = damage.ToString();
        transform.position = target.transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-0.7f, 0.7f));

        transform.LookAt(Camera.main.transform);
    }

    public void ToggleCanvas()
    {
       canvas.enabled = !canvas.enabled;
    }
}
