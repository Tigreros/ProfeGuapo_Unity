using Unity.VisualScripting;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject childPanel;

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
                    
                break;

            case GameState.Pausa:
                

                GameObject prefab = Instantiate(Resources.Load("PauseMenu") as GameObject, this.transform);

                print("SDDSFDSFDFDSAF");

                break;

            case GameState.Recompensa:

                break;
        }
    }

    private void Awake()
    {
        GameStateManager.OnGameStateChanged += HandleGameState;

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
