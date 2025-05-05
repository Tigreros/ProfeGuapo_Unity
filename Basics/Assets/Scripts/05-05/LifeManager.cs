using System.Collections;
using UnityEngine;

public class LifeManager : MonoBehaviour
{

    public static LifeManager lifeManagerInstance
    { get; private set; }

    public int life;
    public GameObject Flick;
    public GameObject UI_Life;

    private void Awake()
    {
        if (lifeManagerInstance != null && lifeManagerInstance != this)
        {
            Destroy(gameObject); return;
        }

        lifeManagerInstance = this;
    }

    public void Start()
    {
        gestorVida();
    }

    public void ReferenceManager(GameObject reference)
    {
        if (reference.CompareTag("Player"))
        {
            Flick = reference;
        }

        if (reference.GetComponent<UI_Life>())
        {
            UI_Life = reference;
        }
    }

    public void gestorVida()
    {
        StartCoroutine("Gestor");
    }

    public IEnumerator Gestor()
    {
        yield return new WaitForSeconds(0.05f);

        if (UI_Life != null && Flick != null)
        {
            life = Flick.GetComponent<VidaFlick>().flickLife;

            if (life >= 0)
            {
                UI_Life.GetComponent<UI_Life>().TurnOnOff(life);
            }
        }
    }
}
