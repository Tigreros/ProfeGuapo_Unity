using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadSceneManagement : MonoBehaviour
{

    public Button buttonSelect;

    public void Start()
    {
        buttonSelect = GetComponent<Button>();

        buttonSelect.onClick.AddListener(() =>
        {
            SceneManagerLoadSceneSaved();
        });
    }

    public void SceneManagerLoadScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        GameStateManager.instance_GameStateManager.ChangeState(GameState.EnJuego);

    }

    public void SceneManagerLoadSceneSaved()
    {
        if(PlayerPrefs.GetInt("SceneNumber") != 0)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("SceneNumber"));
        }
        else
        {
            Debug.LogWarning("No tienes partidas guardadas pringao");
        }
    }

    public void QiutGame()
    {
        Debug.Log("Que hemos salido del game papu");
        Application.Quit();
    }
}