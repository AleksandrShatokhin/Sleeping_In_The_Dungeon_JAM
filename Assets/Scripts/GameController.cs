using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;

    // ссылки по работе с UI элементами и объектами
    [SerializeField] private GameObject mainUI;
    public GameObject GetMainUI() => mainUI;
    public MainUIController GetMainUIController() => mainUI.GetComponent<MainUIController>();
    public GameObject GetButtonUp() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonUp).gameObject;
    public GameObject GetButtonDown() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonDown).gameObject;
    public GameObject GetButtonLeft() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonLeft).gameObject;
    public GameObject GetButtonRight() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonRight).gameObject;

    public RoomController roomController = new RoomController();

    private void Awake()
    {
        instance = this;
    }
}
