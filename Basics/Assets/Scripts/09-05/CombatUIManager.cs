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



    public void SetupUI(CombatantData playerData, CombatantData enemyData)
    {
        playerPortrait.sprite = playerData.portrait;
        playerName.text = playerData.displayName;
        playerHealth.maxValue = playerData.maxHP;
        playerHealth.value = playerData.CurrentHP;

        enemyPortrait.sprite = enemyData.portrait;
        enemyName.text = enemyData.displayName;
        enemyHealth.maxValue = enemyData.maxHP;
        enemyHealth.value = enemyData.CurrentHP;

        battleText.text = $"¡Combate entre {playerName.text} & {enemyName.text}";
    }

    public void ShowPlayerOptions(List<AttackData> availableAttacks, Action<AttackData> onPlayerSelectAttack)
    {
        ClearButtons();
        foreach (var attack in availableAttacks)
        {
            GameObject btn = Instantiate(attackButtonPrefab, attackButtonParent);
            btn.GetComponent<TextMeshProUGUI>().text = attack.name;
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
        if (receiver.displayName == playerName.text)
        {
            playerHealth.value = receiver.CurrentHP;
        }
        else
        {
            enemyHealth.value = receiver.CurrentHP;
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
            currentButtons.Clear();
        }
    }
}