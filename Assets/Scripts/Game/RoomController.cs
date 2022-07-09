using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Premises
{
    public abstract void Enter();
    public abstract void Exit();

    protected void ClearButtonOnScreen()
    {
        GameController.GetInstance().GetButtonUp().SetActive(false);
        GameController.GetInstance().GetButtonDown().SetActive(false);
        GameController.GetInstance().GetButtonLeft().SetActive(false);
        GameController.GetInstance().GetButtonRight().SetActive(false);
    }
}

public class RoomController
{
    public Room_1 room_1 = new Room_1();
    public Room_2 room_2 = new Room_2();
    public Room_3 room_3 = new Room_3();
    public Room_4 room_4 = new Room_4();
    public Room_5 room_5 = new Room_5();
    public Room_6 room_6 = new Room_6();
    public Room_7 room_7 = new Room_7();
    public Room_8 room_8 = new Room_8();
    public Room_9 room_9 = new Room_9();
}

public class SwitcherRoom
{
    public Premises currentRoom { get; private set; }

    public void Init(Premises room)
    {
        currentRoom = room;
        room.Enter();
    }

    public void ChangeRoom(Premises nextRoom)
    {
        currentRoom.Exit();

        currentRoom = nextRoom;
        nextRoom.Enter();
    }
}

public class Room_1 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(0.0f, 0.0f, 10.0f);

    public override void Enter()
    {
        ClearButtonOnScreen();

        if (GameController.GetInstance().GetCounterFlameRoom_1() == 2)
        {
            GameController.GetInstance().GetButtonUp().SetActive(true);
        }
        
        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_2);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_2 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(0.0f, 0.0f, 20.0f);
    private Vector3 pointForMoveDown = new Vector3(0.0f, 0.0f, 0.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonUp().SetActive(true);
        GameController.GetInstance().GetButtonDown().SetActive(true);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_3);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_1);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_3 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(0.0f, 0.0f, 30.0f);
    private Vector3 pointForMoveDown = new Vector3(0.0f, 0.0f, 10.0f);
    private Vector3 pointForMoveLeft = new Vector3(-7.5f, 0.0f, 20.0f);
    //private Vector3 pointForMoveRight = new Vector3(0.0f, 0.0f, 0.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonUp().SetActive(true);
        GameController.GetInstance().GetButtonDown().SetActive(true);
        GameController.GetInstance().GetButtonLeft().SetActive(true);
        GameController.GetInstance().GetButtonRight().SetActive(true);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);
        GameController.GetInstance().GetButtonLeft().GetComponent<ButtonMove>().SetPointToMove(pointForMoveLeft);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_4);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_2);
        GameController.GetInstance().GetButtonLeft().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_6);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_4 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(0.0f, 0.0f, 40.0f);
    private Vector3 pointForMoveDown = new Vector3(0.0f, 0.0f, 20.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonUp().SetActive(true);
        GameController.GetInstance().GetButtonDown().SetActive(true);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_5);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_3);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_5 : Premises
{
    private Vector3 pointForMoveDown = new Vector3(0.0f, 0.0f, 30.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonDown().SetActive(true);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_4);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_6 : Premises
{
    private Vector3 pointForMoveLeft = new Vector3(-12.5f, 0.0f, 20.0f);
    private Vector3 pointForMoveRight = new Vector3(0.0f, 0.0f, 20.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonLeft().SetActive(true);
        GameController.GetInstance().GetButtonRight().SetActive(true);

        GameController.GetInstance().GetButtonLeft().GetComponent<ButtonMove>().SetPointToMove(pointForMoveLeft);
        GameController.GetInstance().GetButtonRight().GetComponent<ButtonMove>().SetPointToMove(pointForMoveRight);

        GameController.GetInstance().GetButtonLeft().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_7);
        GameController.GetInstance().GetButtonRight().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_3);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_7 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(-12.5f, 0.0f, 30.0f);
    private Vector3 pointForMoveDown = new Vector3(-12.5f, 0.0f, 10.0f);
    private Vector3 pointForMoveRight = new Vector3(-7.5f, 0.0f, 20.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonUp().SetActive(true);
        GameController.GetInstance().GetButtonDown().SetActive(true);
        GameController.GetInstance().GetButtonRight().SetActive(true);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);
        GameController.GetInstance().GetButtonRight().GetComponent<ButtonMove>().SetPointToMove(pointForMoveRight);

        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_9);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_8);
        GameController.GetInstance().GetButtonRight().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_6);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_8 : Premises
{
    private Vector3 pointForMoveUp = new Vector3(-12.5f, 0.0f, 20.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonUp().SetActive(true);
        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetPointToMove(pointForMoveUp);
        GameController.GetInstance().GetButtonUp().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_7);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}

public class Room_9 : Premises
{
    private Vector3 pointForMoveDown = new Vector3(-12.5f, 0.0f, 20.0f);

    public override void Enter()
    {
        GameController.GetInstance().GetButtonDown().SetActive(true);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetPointToMove(pointForMoveDown);
        GameController.GetInstance().GetButtonDown().GetComponent<ButtonMove>().SetNextRoom(GameController.GetInstance().roomController.room_7);
    }

    public override void Exit()
    {
        ClearButtonOnScreen();
    }
}