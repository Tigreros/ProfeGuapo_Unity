using UnityEngine;

public class CharacterController_SimpleMove : MonoBehaviour
{
    public float speed = 3.0F;
    public float rotateSpeed = 0.5F;
    CharacterController controller;



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
                rotateSpeed = 0;
                break;

            case GameState.Pausa:
                speed = 0;
                break;

            case GameState.EnJuego:
                speed = 3.0f;
                break;

            case GameState.Recompensa:
                speed = 0;
                break;
        }
    }




    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //GetAxis("Horizontal") nos devueve tres valores: A: -1, Nothing: 0, D:1 
        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);

        // Hemos implementado las variables directamente en la funcion SimpleMove y hemos quitado la comprobación del Vertical a Zero.
        controller.SimpleMove(transform.TransformDirection(Vector3.forward) * speed * Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            print("CXXACSACCDACDSAc");
            GameStateManager.instance_GameStateManager.ChangeState(GameState.Pausa);
        }
    }
}