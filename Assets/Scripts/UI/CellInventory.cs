using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellInventory : Inventory
{
    private Button buttonCell;

    [SerializeField] private Image icon;
    [SerializeField] private AudioClip audioUseCell;

    private void Start()
    {
        icon.sprite = null;

        buttonCell = this.gameObject.GetComponent<Button>();
        buttonCell.onClick.AddListener(UseItemInCell);
    }

    public Sprite GetIcon() => icon.sprite;
    public void SetIcon(Sprite sprite) => icon.sprite = sprite;

    private void UseItemInCell()
    {
        if (icon.sprite.name == "Blade_no_back")
        {
            GameController.GetInstance().GetPlayerController().BladeActive();
        }

        if (icon.sprite.name == "Heal_Green_noBack")
        {
            int maxHealthPlayer = 100;
            int currentHealthPlayer = GameController.GetInstance().GetPlayerController().GetHealthPlayer();
            int differenceHealth = maxHealthPlayer - currentHealthPlayer;

            GameController.GetInstance().GetPlayerController().ChangeHealthPlayer(differenceHealth);
        }

        if (icon.sprite.name == "RedKey-notBackground")
        {
            if (GameController.GetInstance().GetPlayerController().GetCurrentRoom() == GameController.GetInstance().roomController.room_7)
            {
                GameController.GetInstance().GetRoorRoom_8().GetComponent<Door>().OpenDoor(true);
                GameController.GetInstance().GetButtonDown().SetActive(true);
            }
            else
            {
                return;
            }
        }

        if (icon.sprite.name == "BlueKey-notBackground")
        {
            if (GameController.GetInstance().GetPlayerController().GetCurrentRoom() == GameController.GetInstance().roomController.room_4 
                && GameController.GetInstance().roomController.DeathEnemy_4)
            {
                GameController.GetInstance().GetRoorRoom_5().GetComponent<Door>().OpenDoor(true);
                GameController.GetInstance().GetButtonUp().SetActive(true);
            }
            else
            {
                return;
            }
        }

        if (icon.sprite.name == "Heal_Blue_noBack")
        {
            if (GameController.GetInstance().GetPlayerController().GetCurrentRoom() == GameController.GetInstance().roomController.room_8)
            {
                GameController.GetInstance().GetStrangerController().StrangerStandUp();
            }
            else
            {
                return;
            }

        }

        GameController.GetInstance().PlayAudio(audioUseCell);
        icon.sprite = null;
    }
}
