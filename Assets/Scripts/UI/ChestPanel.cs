using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] Button buttonTakeAll, buttonExit;
    [SerializeField] Button buttonItemLeft, buttonItemRight;
    private Image iconLeftItem, iconRightItem;
    private GameObject chest;
    [SerializeField] private AudioClip audioUseCell;

    private void Start()
    {
        GameController.GetInstance().SwitchAllowedRay(false);

        buttonTakeAll.onClick.AddListener(TakeAll);
        buttonExit.onClick.AddListener(Exit);
        buttonItemLeft.onClick.AddListener(TakeLeftItem);
        buttonItemRight.onClick.AddListener(TakeRightItem);

        iconLeftItem = buttonItemLeft.transform.GetChild(0).GetComponent<Image>();
        iconRightItem = buttonItemRight.transform.GetChild(0).GetComponent<Image>();

        iconLeftItem.sprite = GameController.GetInstance().GetChestController().GetCurrentIconLeft();
        iconRightItem.sprite = GameController.GetInstance().GetChestController().GetCurrentIconRight();
        chest = GameController.GetInstance().GetChestController().GetCurrentChest();
    }

    private void TakeAll()
    {
        TakeLeftItem();
        TakeRightItem();
    }

    private void TakeLeftItem()
    {
        GameController.GetInstance().GetInventory().GetComponent<Inventory>().SetItemInCell(iconLeftItem.sprite);
        iconLeftItem.sprite = null;
        chest.GetComponent<Chest>().ChangeIsLeftCellNull();
        GameController.GetInstance().PlayAudio(audioUseCell);
    }

    private void TakeRightItem()
    {
        GameController.GetInstance().GetInventory().GetComponent<Inventory>().SetItemInCell(iconRightItem.sprite);
        iconRightItem.sprite = null;
        chest.GetComponent<Chest>().ChangeIsRightCellNull();
        GameController.GetInstance().PlayAudio(audioUseCell);
    }

    private void Exit()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().SwitchAllowedRay(true);
    }
}
