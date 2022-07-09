using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject inventory;

    [SerializeField] private Button buttonPlayerMoveUp, buttonPlayerMoveDown, buttonPlayerMoveLeft, buttonPlayerMoveRight;
    [SerializeField] private Button buttonCallMenu;
    [SerializeField] private Button buttonCallInventory;

    private void Start()
    {
        buttonPlayerMoveUp.onClick.AddListener(PlayerMoveUp);
        buttonPlayerMoveDown.onClick.AddListener(PlayerMoveDown);
        buttonPlayerMoveLeft.onClick.AddListener(PlayerMoveLeft);
        buttonPlayerMoveRight.onClick.AddListener(PlayerMoveRight);
        buttonCallMenu.onClick.AddListener(CallMenu);
        buttonCallInventory.onClick.AddListener(CallInventory);
    }

    private void PlayerMoveUp()
    {
        playerController.Movement(buttonPlayerMoveUp.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveUp.GetComponent<ButtonMove>().GetNextRoom());
    }

    private void PlayerMoveDown()
    {
        playerController.Movement(buttonPlayerMoveDown.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveDown.GetComponent<ButtonMove>().GetNextRoom());
    }

    private void PlayerMoveLeft()
    {
        playerController.Movement(buttonPlayerMoveLeft.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveLeft.GetComponent<ButtonMove>().GetNextRoom());
    }

    private void PlayerMoveRight()
    {
        playerController.Movement(buttonPlayerMoveRight.GetComponent<ButtonMove>().GetPointToMove(), buttonPlayerMoveRight.GetComponent<ButtonMove>().GetNextRoom());
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
}