using UnityEngine;
using UnityEngine.UI;

public class B_Continue : MonoBehaviour
{
    private Button buttonSelect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        buttonSelect = GetComponent<Button>();

        buttonSelect.onClick.AddListener(() =>
        {
            GameStateManager.instance_GameStateManager.ChangeState(GameState.EnJuego);
        });
    }
}
