using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{
    // записываем и передаем значения по точке для движения
    [SerializeField] private Vector3 pointToMove;
    public Vector3 GetPointToMove() => pointToMove;
    public void SetPointToMove(Vector3 point) => pointToMove = point;

    // записываем и передаем значения по новой комнате для дальнейшего движения
    private Premises nextRoom;
    public Premises GetNextRoom() => nextRoom;
    public void SetNextRoom(Premises room) => nextRoom = room;
}
