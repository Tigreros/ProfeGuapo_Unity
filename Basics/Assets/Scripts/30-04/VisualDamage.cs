using TMPro;
using UnityEngine;

public class VisualDamage : MonoBehaviour
{
    public static VisualDamage visualDamageInstance { get; private set; }

    public GameObject g_target;
    public float f_damage;
    private Canvas canvas;
    private Animator animator;

    public void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

        if (visualDamageInstance != null && visualDamageInstance != this)
        {
            Destroy(gameObject); return;
        }

        visualDamageInstance = this;
        DontDestroyOnLoad(this);
    }

    public void VisualDamageFunction(GameObject target, float damage)
    {
        g_target = target;
        f_damage = damage;
        canvas.enabled = true;

        transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = damage.ToString();
        transform.position = target.transform.position + new Vector3(0, Random.Range(0.5f, 2), Random.Range(-1, 1));

        transform.LookAt(Camera.main.transform);
        // Lanzaremos el trigger de la animación
    }
}
