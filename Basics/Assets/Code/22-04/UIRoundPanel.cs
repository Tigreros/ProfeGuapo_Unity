using System;
using UnityEngine;

public class UIRoundPanel : MonoBehaviour
{
    public GameObject text;


    private void OnEnable()
    {
        EventBus.Subscribe("OnStartCombat", MostrarPanel);
        EventBus.Subscribe("OnEndCombat", OcultarPanel);
    }

    // cuando el objeto se destruye o se desactiva
    private void OnDisable()
    {
        EventBus.Unsubscribe("OnStartCombat", MostrarPanel);
        EventBus.Unsubscribe("OnEndCombat", OcultarPanel);
    }


    private void Start()
    {
        text = transform.GetChild(0).gameObject;
    }


    private void MostrarPanel() => text.SetActive(true);
    private void OcultarPanel() => text.SetActive(false);
}
