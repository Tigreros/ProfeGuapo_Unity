using UnityEngine;
using System;
public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance_GameStateManager
    { get; private set; }

    [SerializeField]
    public GameState currentState
    { get; private set; }

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        if (instance_GameStateManager != null && instance_GameStateManager != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_GameStateManager = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeState(GameState.Inicio);
    }

    private void Update()
    {
        state = currentState;
    }

    public void ChangeState(GameState newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        OnGameStateChanged?.Invoke(currentState);

        Debug.Log($"El nuevo estado de juego es {currentState}");
    }

}