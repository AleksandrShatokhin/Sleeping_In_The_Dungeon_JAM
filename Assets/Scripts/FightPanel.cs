using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightPanel : MonoBehaviour
{
    [SerializeField] private Button buttonAttack, buttonBlock, buttonExit;
    [SerializeField] private Slider healthPlayer, healthEnemy;
    [SerializeField] private GameObject deathPanel;

    private PlayerController player;
    private Enemy enemy;
    public Enemy SetEnemy(Enemy enemy) => this.enemy = enemy;

    void Start()
    {
        GameController.GetInstance().TurnOffMainUI();

        player = GameController.GetInstance().GetPlayerController();
        player.RotatePlayerOnEnemy(enemy.transform);

        healthPlayer.value = player.GetHealthPlayer();
        healthEnemy.value = enemy.GetHealthEnemy();

        buttonAttack.onClick.AddListener(ButtonAttack);
        buttonBlock.onClick.AddListener(ButtonBlock);
        buttonExit.onClick.AddListener(Exit);
    }

    public void ChangeHealthPlayer(int damage)
    {
        if (player.CheckIsBlock())
        {
            healthPlayer.value -= damage / 4;
            player.ChangeHealthPlayer(-(damage / 4));
            player.Block(false);
        }
        else
        {
            healthPlayer.value -= damage;
            player.ChangeHealthPlayer(-damage);
            player.Block(false);
        }

        if (healthPlayer.value <= 0)
        {
            Instantiate(deathPanel, deathPanel.transform.position, deathPanel.transform.rotation);
            GameController.GetInstance().TurnOffMainUI();
            Exit();
        }
    }

    public void ChangeHealthEnemy(int damage)
    {
        if (enemy.Fighting(this))
        {
            healthEnemy.value -= damage;
            enemy.ChangeHealthEnemy(-damage);
        }
        else
        {
            healthEnemy.value -= damage / 4;
            enemy.ChangeHealthEnemy(-(damage / 4));
        }

        if (healthEnemy.value <= 0)
        {
            enemy.Death();
            CheckEnemyID();
            Exit();
        }
    }

    private void Exit()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().TurnOnMainUI();
    }

    private void ButtonAttack()
    {
        player.Attack(this);
        ButtonActivityOnScreen(false);
    }

    private void ButtonBlock()
    {
        player.Block(true);
        enemy.Fighting(this);
        ButtonActivityOnScreen(false);
    }

    private void ButtonActivityOnScreen(bool value)
    {
        buttonAttack.transform.gameObject.SetActive(value);
        buttonBlock.transform.gameObject.SetActive(value);

        StartCoroutine(ReturnActiveButtons());
    }

    private IEnumerator ReturnActiveButtons()
    {
        yield return new WaitForSeconds(1.5f);

        ButtonActivityOnScreen(true);
        StopAllCoroutines();
    }

    private void CheckEnemyID()
    {
        switch (enemy.GetEnemyID())
        {
            case 1:
                GameController.GetInstance().roomController.DeathEnemy_1 = true;
                GameController.GetInstance().GetButtonUp().SetActive(true);
                break;

            case 2:
                GameController.GetInstance().roomController.DeathEnemy_2 = true;
                GameController.GetInstance().GetButtonUp().SetActive(true);
                break;

            case 3:
                GameController.GetInstance().roomController.DeathEnemy_3 = true;
                GameController.GetInstance().GetButtonLeft().SetActive(true);
                break;

            case 4:
                GameController.GetInstance().roomController.DeathEnemy_4 = true;
                GameController.GetInstance().GetButtonUp().SetActive(true);
                break;

            case 5:
                GameController.GetInstance().roomController.DeathEnemy_5 = true;
                GameController.GetInstance().GetButtonUp().SetActive(true);
                break;
        }
    }
}
