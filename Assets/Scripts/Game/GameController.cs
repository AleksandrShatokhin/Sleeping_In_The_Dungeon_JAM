using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static GameController instance;
    public static GameController GetInstance() => instance;


    private AudioSource audioSource;

    public RoomController roomController = new RoomController();
    private int counterFlameRoom_1 = 0, counterFlameRoom_9 = 12;
    public int GetCounterFlameRoom_1() => counterFlameRoom_1;
    public int GetCounterFlameRoom_9() => counterFlameRoom_9;

    private bool isPauseGameTime;
    public bool IsPauseGameTime() => isPauseGameTime;
    [SerializeField] private GameObject inventory;
    public GameObject GetInventory() => inventory;

    [SerializeField] private GameObject picture;
    public Picture GetPictureComponent() => picture.GetComponent<Picture>();

    // получение ссылок на компоненты, которые находятся на объекте Game
    private NoteController noteController;
    public NoteController GetNoteController() => noteController = GetComponent<NoteController>();

    private ChestController chestController;
    public ChestController GetChestController() => chestController = GetComponent<ChestController>();

    // ссылки по работе с UI элементами и объектами
    [SerializeField] private GameObject mainUI;
    public GameObject GetMainUI() => mainUI;
    public MainUIController GetMainUIController() => mainUI.GetComponent<MainUIController>();
    public GameObject GetButtonUp() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonUp).gameObject;
    public GameObject GetButtonDown() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonDown).gameObject;
    public GameObject GetButtonLeft() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonLeft).gameObject;
    public GameObject GetButtonRight() => GetMainUI().transform.GetChild((int)ListButtonMove.ButtonRight).gameObject;


    [SerializeField] private GameObject door_FirstRoom, door_Room_9, door_Room_8, door_Room_5, final_Door;
    public GameObject GetRoorRoom_5() => door_Room_5;
    public GameObject GetRoorRoom_8() => door_Room_8;
    public GameObject GetFinalDoor() => final_Door;

    [SerializeField] private GameObject player;
    public PlayerController GetPlayerController() => player.GetComponent<PlayerController>();

    [SerializeField] private GameObject stranger;
    public StrangerController GetStrangerController() => stranger.GetComponent<StrangerController>();
    private bool isWin = false;
    public bool GetValue_IsWin() => isWin;
    public void SetValueTrueIsWin() => isWin = true;

    // изменение возможности пускать луч
    private bool allowedRay;
    public bool CheckValueAllowedRay() => allowedRay;
    public void SwitchAllowedRay(bool value) => allowedRay = value;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        SwitchAllowedRay(true);
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

    public void CounterFlameRoom_9(int count)
    {
        counterFlameRoom_9 += count;

        if (counterFlameRoom_9 == 0)
        {
            door_Room_9.GetComponent<Door>().OpenDoor(true);

            if (GetPlayerController().GetCurrentRoom() == GameController.GetInstance().roomController.room_7)
            {
                GetButtonUp().SetActive(true);
                GetPlayerController().RebootCurrentRoom();
            }
        }

        if (counterFlameRoom_9 > 0)
        {
            door_Room_9.GetComponent<Door>().OpenDoor(false);

            if (GetPlayerController().GetCurrentRoom() == GameController.GetInstance().roomController.room_7)
            {
                GetButtonUp().SetActive(false);
            }
        }

        Debug.Log(counterFlameRoom_9);
    }

    public void PauseGameTimeAndMainUI(bool value)
    {
        if (!value)
        {
            mainUI.SetActive(value);
            Time.timeScale = 0.0f;
            isPauseGameTime = true;
        }
        else
        {
            mainUI.SetActive(value);
            Time.timeScale = 1.0f;
            isPauseGameTime = false;
        }
    }

    public void TurnOffMainUI() => mainUI.SetActive(false);
    public void TurnOnMainUI() => mainUI.SetActive(true);

    public void CloseUIPanel()
    {
        GameObject panel = GameObject.FindGameObjectWithTag("UI_Panel");
        Destroy(panel);

        PauseGameTimeAndMainUI(true);
    }

    public void OutputMessageForPlayer(string message) => GetMainUIController().SetCenterText(message);

    public void PlayAudio(AudioClip audio) => audioSource.PlayOneShot(audio, 1.0f);
    public void PlayAudio(AudioClip audio, float volume) => audioSource.PlayOneShot(audio, volume);
}