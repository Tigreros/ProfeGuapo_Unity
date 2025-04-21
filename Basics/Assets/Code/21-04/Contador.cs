using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Contador : MonoBehaviour
{

    public float count;






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
                StartCoroutine("CountDecrease");
                break;

            case GameState.EnJuego:

                break;

            case GameState.Pausa:


                break;

            case GameState.Recompensa:

                break;
        }
    }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CountDecrease()
    {
        yield return new WaitForSeconds(1);
        count--;
        if (count <= 0)
        {
            StopCoroutine("CountDecrease");
            GameStateManager.instance_GameStateManager.ChangeState(GameState.EnJuego);
            yield return null;
        }
        StartCoroutine("CountDecrease");
    }
}
