using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : ObjectManager
{
    private Animator anim_Enemy;

    private const string messageForPlayer_RU = "Прежде нужно найти оружие";
    private const string messageForPlayer_EN = "First you need to find a weapon";

    [SerializeField] private GameObject fightPanel;
    [SerializeField] private int health;
    [SerializeField] private int id;
    public int GetEnemyID() => id;

    private void Start()
    {
        anim_Enemy = GetComponentInChildren<Animator>();
    }

    public override void InteractionWithPlayer()
    {
        if (GameController.GetInstance().GetPlayerController().isBladeInHand)
        {
            GameObject panel = Instantiate(fightPanel, fightPanel.transform.position, fightPanel.transform.rotation);
            panel.GetComponent<FightPanel>().SetEnemy(this);
        }
        else
        {
            if (LanguageController.GetLanguage() == (int)ListLanguage.English)
            {
                GameController.GetInstance().OutputMessageForPlayer(messageForPlayer_EN);
            }

            if (LanguageController.GetLanguage() == (int)ListLanguage.Russian)
            {
                GameController.GetInstance().OutputMessageForPlayer(messageForPlayer_RU);
            }
        }
    }

    public bool Fighting(FightPanel panel)
    {
        bool isDamage;
        float point = Random.Range(0, 10);

        if (point < 5)
        {
            isDamage = true;
            anim_Enemy.SetTrigger("isAttack");

            int damage = Random.Range(2, 10);
            //int damage = Random.Range(80, 100);
            panel.ChangeHealthPlayer(damage);
        }
        else
        {
            isDamage = false;
            anim_Enemy.SetTrigger("isBlock");
        }

        return isDamage;
    }

    public int GetHealthEnemy() => health;
    public void ChangeHealthEnemy(int health) => this.health += health;
    public void Death()
    {
        Destroy(this.gameObject);
    }
}
