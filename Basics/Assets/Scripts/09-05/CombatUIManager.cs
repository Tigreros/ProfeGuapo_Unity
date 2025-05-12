using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CombatUIManager : MonoBehaviour 
{
    [Header("UI - Jugador")]
    public Image playerPortrait;
    public TextMeshProUGUI playerName;
    public Slider playerHealth;

    [Header("UI - Enemigo")]
    public Image enemyPortrait;
    public TextMeshProUGUI enemyName;
    public Slider enemyHealth;

    [Header("Panel de Acciones")]
    public GameObject attackButtonPrefab;
    public Transform attackButtonParent;

    [Header("Mensajes")]
    public TextMeshProUGUI battleText;
    public List<GameObject> currentButtons = new();

    public CombatantData player;
    public CombatantData enemy;



    public void SetupUI(CombatantData playerData, CombatantData enemyData)
    {
        player = playerData;
        enemy = enemyData;

        playerPortrait.sprite = player.portrait;
        playerName.text = player.displayName;
        playerHealth.maxValue = player.maxHP;
        playerHealth.value = player.CurrentHP;

        enemyPortrait.sprite = enemy.portrait;
        enemyName.text = enemy.displayName;
        enemyHealth.maxValue = enemy.maxHP;
        enemyHealth.value = enemy.maxHP;
        enemy.CurrentHP = enemy.maxHP;

        battleText.text = $"¡Combate entre {playerName.text} & {enemyName.text}";
    }

    public void ShowPlayerOptions(List<AttackData> availableAttacks, Action<AttackData> onPlayerSelectAttack)
    {
        ClearButtons();
        foreach (var attack in availableAttacks)
        {
            GameObject btn = Instantiate(attackButtonPrefab, attackButtonParent);
            btn.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = attack.name;
            currentButtons.Add(btn);

            btn.GetComponent<Button>().onClick.AddListener(() => 
            {
                onPlayerSelectAttack.Invoke(attack);
            });
        }

        battleText.text = "¡Elige un ataque!";
    }

    public void ShowAttack(string displayName, string attackName)
    {
        battleText.text = $"{displayName} uso {attackName}";
    }

    public void ShowEffect(CombatantData receiver, StatusEffectType attackEffect)
    {
        battleText.text += $" \n {receiver.displayName} uso {attackEffect.ToString()}";
    }

    public void ShowUpdateHealth(CombatantData receiver)
    {
        if (receiver == player)
        {
            playerHealth.value = player.CurrentHP;
        }
        else
        {
            enemyHealth.value = enemy.CurrentHP;
        }
    }

    public void ShowEnemyThinking()
    {
        battleText.text = "¡El enemigo esta pensando!";
        ClearButtons();
    }


    public void ShowBattleResult(bool playerWon)
    {
        battleText.text = playerWon ? "Has ganado" : "Has perdido maldito";
        ClearButtons();
    }

    private void ClearButtons()
    {
        foreach (var btn in currentButtons)
        {
            Destroy(btn);
        }
        currentButtons.Clear();
    }
}