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
    }

    private IEnumerator SwitchActiveButtonMove()
    {
        TurnOffButtonMove(false);

        yield return new WaitForSeconds(1.8f);

        TurnOffButtonMove(true);
        StopAllCoroutines();
    }
}