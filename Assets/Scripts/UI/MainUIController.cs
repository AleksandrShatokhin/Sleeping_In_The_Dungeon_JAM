using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUIController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    [SerializeField] private Button buttonPlayerMoveUp, buttonPlayerMoveDown, buttonPlayerMoveLeft, buttonPlayerMoveRight;

    private void Start()
    {
        buttonPlayerMoveUp.onClick.AddListener(PlayerMoveUp);
        buttonPlayerMoveDown.onClick.AddListener(PlayerMoveDown);
        buttonPlayerMoveLeft.onClick.AddListener(PlayerMoveLeft);
        buttonPlayerMoveRight.onClick.AddListener(PlayerMoveRight);
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
}