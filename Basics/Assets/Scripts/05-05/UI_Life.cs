using UnityEngine;
using UnityEngine.UI;

public class UI_Life : MonoBehaviour
{

    public Image[] UI_lifeHeart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int childCount = transform.childCount;
        UI_lifeHeart = new Image[childCount];

        for (int i = 0; i < childCount; i++)
        {
            UI_lifeHeart[i] = transform.GetChild(i).GetComponentInChildren<Image>();
        }

        LifeManager.lifeManagerInstance.ReferenceManager(this.gameObject);
    }

    public void TurnOnOff(int x)
    {
        for (int i = 0; i < UI_lifeHeart.Length; i++)
        {
            if(i < x)
            {
                UI_lifeHeart[i].enabled = true;
            }
            else
            {
                UI_lifeHeart[i].enabled = false;
            }
        }
    }
}
