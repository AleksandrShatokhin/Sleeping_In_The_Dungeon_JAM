using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    private const string buttonCallInventoryText_RU = "Инвентарь";
    private const string buttonCallInventoryText_EN = "Inventory";

    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject inventory;

    [SerializeField] private Button buttonPlayerMoveUp, buttonPlayerMoveDown, buttonPlayerMoveLeft, buttonPlayerMoveRight;
    [SerializeField] private Button buttonCallMenu;
    [SerializeField] private Button buttonCallInventory;
    [SerializeField] private TextMeshProUGUI centerText;
    

    private void Start()
    {
        LanguageMenu(LanguageController.GetLanguage());

        buttonPlayerMoveUp.onClick.AddListener(PlayerMoveUp);
        buttonPlayerMoveDown.onClick.AddListener(PlayerMoveDown);
        buttonPlayerMoveLeft.onClick.AddListener(PlayerMoveLeft);
        buttonPlayerMoveRight.onClick.AddListener(PlayerMoveRight);
        buttonCallMenu.onClick.AddListener(CallMenu);
        buttonCallInventory.onClick.AddListener(CallInventory);

        centerText.text = null;
    }

    private void PlayerMoveUp()
    {
        playerController.Movement(buttonPlayerMoveUp.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveUp.GetComponent<ButtonMove>().GetNextRoom());
        StartCoroutine(SwitchActiveButtonMove());
    }

    private void PlayerMoveDown()
    {
        playerController.Movement(buttonPlayerMoveDown.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveDown.GetComponent<ButtonMove>().GetNextRoom());
        StartCoroutine(SwitchActiveButtonMove());
    }

    private void PlayerMoveLeft()
    {
        playerController.Movement(buttonPlayerMoveLeft.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveLeft.GetComponent<ButtonMove>().GetNextRoom());
        StartCoroutine(SwitchActiveButtonMove());
    }

    private void PlayerMoveRight()
    {
        playerController.Movement(buttonPlayerMoveRight.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveRight.GetComponent<ButtonMove>().GetNextRoom());
        StartCoroutine(SwitchActiveButtonMove());
    }

    private void CallMenu()
    {
        Instantiate(menuPanel, menuPanel.transform.position, menuPanel.transform.rotation);
        GameController.GetInstance().PauseGameTimeAndMainUI(false);
    }

    private void CallInventory()
    {
        inventory.GetComponent<Animator>().SetBool("isOpen", true);
    }

    private void TurnOffButtonMove(bool value)
    {
        buttonPlayerMoveUp.image.enabled = value;
        buttonPlayerMoveDown.image.enabled = value;
        buttonPlayerMoveLeft.image.enabled = value;
        buttonPlayerMoveRight.image.enabled = value;

        buttonCallMenu.gameObject.SetActive(value);
        buttonCallInventory.gameObject.SetActive(value);

        GameController.GetInstance().SwitchAllowedRay(value);
    }

    private IEnumerator SwitchActiveButtonMove()
    {
        TurnOffButtonMove(false);

        yield return new WaitForSeconds(1.8f);

        TurnOffButtonMove(true);
        StopAllCoroutines();
    }

    public void SetCenterText(string text)
    {
        centerText.text = text;

        StartCoroutine(CenterTextNull());
    }

    private IEnumerator CenterTextNull()
    {
        yield return new WaitForSeconds(1.5f);

        centerText.text = null;
    }

    private void LanguageMenu(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            buttonCallInventory.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonCallInventoryText_EN;
        }

        if (language == (int)ListLanguage.Russian)
        {
            buttonCallInventory.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonCallInventoryText_RU;
        }
    }
}