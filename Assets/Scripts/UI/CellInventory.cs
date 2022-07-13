using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellInventory : Inventory
{
    private Button buttonCell;

    [SerializeField] private Image icon;

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

        icon.sprite = null;
    }
}
