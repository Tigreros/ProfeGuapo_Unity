using System;
using UnityEngine;
using TMPro;

public class RespuestaGPTUI : MonoBehaviour
{

    public TextMeshProUGUI TMP_respuestaGPT;
    //LayerMask layerMask = LayerMask.GetMask("UI");

    private void OnEnable()
    {
        EventBus.Subscribe("RespuestaSucced", RespuestaSucced);
        EventBus.Subscribe("ClearRespuesta", ClearRespuesta);
    }

    // cuando el objeto se destruye o se desactiva
    private void OnDisable()
    {
        EventBus.Unsubscribe("RespuestaSucced", RespuestaSucced);
        EventBus.Unsubscribe("ClearRespuesta", ClearRespuesta);
    }

    private void RespuestaSucced()
    {
        TMP_respuestaGPT = GameObject.Find("ContainerAnswer").GetComponent<TextMeshProUGUI>();

        if (EventBus.textGPT.Length < 220)
        {
            TMP_respuestaGPT.fontSize = 30;
            print("GRANDE");
        }

        else if (EventBus.textGPT.Length > 220 && EventBus.textGPT.Length < 400)
        {
            TMP_respuestaGPT.fontSize = 20;
            print("MEDIO");
        }

        else if (EventBus.textGPT.Length > 400)
        {
            TMP_respuestaGPT.fontSize = 12;
            print("PEQUEÑO");
        }

        TMP_respuestaGPT.text = EventBus.textGPT;

    }

    private void ClearRespuesta()
    {
        TMP_respuestaGPT.text = "";
    }

}
