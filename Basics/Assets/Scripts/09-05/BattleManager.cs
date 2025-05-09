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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(StartBattle());
    }

    public IEnumerator StartBattle()
    {
        inBattle = true;
        uiManager.SetupUI(playerData, enemyData);
        yield return new WaitForSeconds(2);
        PlayerTurn();
    }

    private void PlayerTurn()
    {
        playerTurn = true;
        uiManager.ShowPlayerOptions(playerData.availableAttacks, OnPlayerSelectAttack);
    }

    private void OnPlayerSelectAttack(AttackData selectedAttack)
    {
        playerTurn = false;
        StartCoroutine(ExecuteAttack(playerData, enemyData, selectedAttack, EnemyTurn));
    }

    private void EnemyTurn()
    {
        if(enemyData.CurrentHP <= 0)
        {
            EndBattle(true);
            return;
        }

        uiManager.ShowEnemyThinking();
        StartCoroutine(EnemyAttack());
    }

    private IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1.5f);

        AttackData randomAttack = enemyData.availableAttacks[UnityEngine.Random.Range(0,enemyData.availableAttacks.Count)];

        yield return ExecuteAttack(enemyData, playerData, randomAttack, () =>
        {
            if (playerData.CurrentHP <= 0)
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
        yield return new WaitForSeconds(1);

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