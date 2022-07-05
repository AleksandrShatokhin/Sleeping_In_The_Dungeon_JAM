using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;


    public RoomController roomController = new RoomController();
    private int counterFlameRoom_1 = 0;
    public int GetCounterFlameRoom_1() => counterFlameRoom_1;


    private NoteController noteController;
    public NoteController GetNoteController() => noteController = GetComponent<NoteController>();

    // ссылки по работе с UI элементами и объектами
    [SerializeField] private GameObject mainUI;
    public GameObject GetMainUI() => mainUI;
    public MainUIController GetMainUIController() => mainUI.GetComponent<MainUIController>();
    public GameObject GetButtonUp() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonUp).gameObject;
    public GameObject GetButtonDown() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonDown).gameObject;
    public GameObject GetButtonLeft() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonLeft).gameObject;
    public GameObject GetButtonRight() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonRight).gameObject;


    [SerializeField] private GameObject door_FirstRoom;
    [SerializeField] private GameObject player;
    public PlayerController GetPlayerController() => player.GetComponent<PlayerController>();

    private void Awake()
    {
        instance = this;
    }

    public void CounterFlameRoom_1(int count)
    {
        counterFlameRoom_1 += count;

        if (counterFlameRoom_1 >= 2)
        {
            door_FirstRoom.GetComponent<Door>().OpenDoor(true);
            GetButtonUp().SetActive(true);
        }

        if (counterFlameRoom_1 < 2)
        {
            door_FirstRoom.GetComponent<Door>().OpenDoor(false);
            GetButtonUp().SetActive(false);
        }
    }
}