using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Canvas canvas;

    public float maxHealthLocal;

    public Image image;

    public Transform playerAssing;

    public void Update()
    {
        if(playerAssing != null)
        {
            canvas.transform.LookAt(playerAssing);
        }
    }

    public void Setup(float maxHealth)
    {
        healthSlider.maxValue = maxHealth;
        maxHealthLocal = maxHealth;
        healthSlider.value = maxHealth;
        image = canvas.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    }

    public void UpdateHealth(float currentHealth)
    {
        healthSlider.value = currentHealth;
        if(currentHealth < (maxHealthLocal / 3) + (maxHealthLocal / 3) && currentHealth > (maxHealthLocal / 3)) image.color = Color.yellow;
        if(currentHealth < (maxHealthLocal / 3)) image.color = Color.red;
    }

    public void SetVisible(bool visible)
    {
        canvas.enabled = visible;
    }

    public void FollowCamera(Transform player)
    {
        playerAssing = player;
    }
}
