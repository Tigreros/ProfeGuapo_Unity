using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public GameObject childPanel;
    public GameObject prefab;


    private void OnEnable()
    {
        GameStateManager.OnGameStateChanged += HandleGameState;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandleGameState;
    }
    void HandleGameState(GameState state)
    {

        switch (state)
        {
            case GameState.Combate:

                break;

            case GameState.EnJuego:
                if (prefab != null) Destroy(prefab);
                break;

            case GameState.Pausa:
                if (prefab != null) { prefab.SetActive(true); return; }
                
                prefab = Instantiate(Resources.Load("PauseMenu") as GameObject, this.transform);
                
                break;

            case GameState.Recompensa:

                break;
        }
    }

    //private void Awake()
    //{
    //    GameStateManager.OnGameStateChanged += HandleGameState;
    //}

}
