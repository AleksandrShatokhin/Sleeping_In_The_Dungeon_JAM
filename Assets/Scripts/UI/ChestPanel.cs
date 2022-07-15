using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChestPanel : MonoBehaviour
{
    private const string buttonTakeAllText_RU = "Взять всё";
    private const string buttonTakeAllText_EN = "Take All";
    private const string buttonExitText_RU = "Выход";
    private const string buttonExitText_EN = "Exit";

    [SerializeField] Button buttonTakeAll, buttonExit;
    [SerializeField] Button buttonItemLeft, buttonItemRight;
    private Image iconLeftItem, iconRightItem;
    private GameObject chest;
    [SerializeField] private AudioClip audioUseCell;

    private void Start()
    {
        LanguageButtons(LanguageController.GetLanguage());
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

    private void LanguageButtons(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            buttonTakeAll.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonTakeAllText_EN;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_EN;
        }

        if (language == (int)ListLanguage.Russian)
        {
            buttonTakeAll.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonTakeAllText_RU;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_RU;
        }
    }
}
