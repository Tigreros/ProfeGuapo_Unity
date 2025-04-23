using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //public GameObject childPanel;
    public GameObject prefab;


    private void OnEnable()
    {
        //GameStateManager.OnGameStateChanged += HandleGameState;
    }

    private void OnDisable()
    {
        GameStateManager.OnGameStateChanged -= HandleGameState;
    }
    void HandleGameState(GameState state)
    {
        //print("jnhgclyfluyfck,ckgckgcjdjxsjfxsjmfdxjm");



        switch (state)
        {
            case GameState.Combate:

                break;

            case GameState.EnJuego:
                if (prefab != null) return;
                break;

            case GameState.Pausa:
                if (prefab != null) { prefab.SetActive(true); return; }
                
                prefab = Instantiate(Resources.Load("PauseMenu") as GameObject, this.transform);
                
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
