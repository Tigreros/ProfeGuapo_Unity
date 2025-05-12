using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManagerPersistant : MonoBehaviour
{
    public static BattleManagerPersistant instance_BattleManagerPersistant
    { get; private set; }

    public CombatantData[] enemys;
    public int indexEnemy;
    public bool firstAttack;

    private void Awake()
    {
        if (instance_BattleManagerPersistant != null && instance_BattleManagerPersistant != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance_BattleManagerPersistant = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        enemys = Resources.LoadAll("Enemy_ScriptableObjects/Patrick", typeof(CombatantData)).Cast<CombatantData>().ToArray();
    }

    public void LoadBattleScene(int index, bool firsto)
    {
        indexEnemy = index;
        firstAttack = firsto;
        SceneManager.LoadScene("CombatScene");
    }
}
