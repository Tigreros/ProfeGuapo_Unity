using System;
using System.Collections;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public CombatantData playerData;
    public CombatantData enemyData;

    public CombatUIManager uiManager;

    public bool playerTurn = true;
    public bool inBattle = false;

    public CombatantData player;
    public CombatantData enemy;

    public bool firstAttack;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (enemyData == null)
        {
            enemyData = BattleManagerPersistant.instance_BattleManagerPersistant.enemys[BattleManagerPersistant.instance_BattleManagerPersistant.indexEnemy];
            firstAttack = BattleManagerPersistant.instance_BattleManagerPersistant.firstAttack;
        }
        enemy = enemyData;

        playerData = Resources.Load<CombatantData>("player");
        player = playerData;

        uiManager = GameObject.Find("CombatUIManager").GetComponent<CombatUIManager>();

        StartCoroutine(StartBattle());
    }

    public IEnumerator StartBattle()
    {
        yield return new WaitForSeconds(2f);
        inBattle = true;
        uiManager.SetupUI(player, enemy);
        yield return new WaitForSeconds(2);
        
        if (firstAttack) { PlayerTurn(); }
        else { EnemyTurn(); }
    }

    private void PlayerTurn()
    {
        playerTurn = true;
        uiManager.ShowPlayerOptions(player.availableAttacks, OnPlayerSelectAttack);
    }

    private void OnPlayerSelectAttack(AttackData selectedAttack)
    {
        playerTurn = false;
        StartCoroutine(ExecuteAttack(player, enemy, selectedAttack, EnemyTurn));
    }

    private void EnemyTurn()
    {
        if(enemy.CurrentHP <= 0)
        {
            EndBattle(true);
            return;
        }

        uiManager.ShowEnemyThinking();
        StartCoroutine(EnemyAttack());
    }

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(3f);

        AttackData randomAttack = enemy.availableAttacks[UnityEngine.Random.Range(0, enemy.availableAttacks.Count)];

        yield return ExecuteAttack(enemy, player, randomAttack, () =>
        {
            if (player.CurrentHP <= 0)
            {
                EndBattle(false);
            }
            else
            {
                PlayerTurn();
            }
        });
    }

    private IEnumerator ExecuteAttack(CombatantData attacker, CombatantData receiver, AttackData attack, System.Action onComplete)
    {
        uiManager.ShowAttack(attacker.displayName, attack.attackName);
        yield return new WaitForSeconds(3);

        receiver.CurrentHP -= attack.damage;
        receiver.CurrentHP = Mathf.Max(0,receiver.CurrentHP);

        uiManager.ShowUpdateHealth(receiver);

        if (attack.attackEffect != StatusEffectType.None)
        {
            uiManager.ShowEffect(receiver, attack.attackEffect);
            yield return new WaitForSeconds(1);
        }

        onComplete?.Invoke();
    }

    private void EndBattle(bool playerWon)
    {
       inBattle = false;
       uiManager.ShowBattleResult(playerWon);
    }
}