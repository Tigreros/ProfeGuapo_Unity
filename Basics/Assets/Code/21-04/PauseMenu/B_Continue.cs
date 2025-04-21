using UnityEngine;

public class B_Continue : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void ContinueFunction() => GameStateManager.instance_GameStateManager.ChangeState(GameState.EnJuego);
}
