using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightPanel : MonoBehaviour
{
    [SerializeField] private Button buttonAttack, buttonBlock, buttonExit;
    [SerializeField] private Slider healthPlayer, healthEnemy;

    [SerializeField] private AudioClip audioAttack, audioBlock;

    private PlayerController player;
    private Enemy enemy;
    public Enemy SetEnemy(Enemy enemy) => this.enemy = enemy;

    void Start()
    {
        GameController.GetInstance().TurnOffMainUI();
        GameController.GetInstance().SwitchAllowedRay(false);

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
            GameController.GetInstance().PlayAudio(audioBlock);
        }
        else
        {
            healthPlayer.value -= damage;
            player.ChangeHealthPlayer(-damage);
            player.Block(false);
            GameController.GetInstance().PlayAudio(audioAttack);
        }

        if (healthPlayer.value <= 0)
        {
            player.PlayerDeath();
            Exit();
        }
    }

    public void ChangeHealthEnemy(int damage)
    {
        if (enemy.Fighting(this))
        {
            healthEnemy.value -= damage;
            enemy.ChangeHealthEnemy(-damage);
            GameController.GetInstance().PlayAudio(audioAttack);
        }
        else
        {
            healthEnemy.value -= damage / 4;
            enemy.ChangeHealthEnemy(-(damage / 4));
            GameController.GetInstance().PlayAudio(audioBlock);
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
        GameController.GetInstance().SwitchAllowedRay(true);
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
                if (GameController.GetInstance().GetRoorRoom_5().GetComponent<Door>().doorIsOpen)
                {
                    GameController.GetInstance().GetButtonUp().SetActive(true);
                }
                break;

            case 5:
                GameController.GetInstance().roomController.DeathEnemy_5 = true;
                if (GameController.GetInstance().GetCounterFlameRoom_9() == 0)
                {
                    GameController.GetInstance().GetButtonUp().SetActive(true);
                }
                break;
        }
    }
}
