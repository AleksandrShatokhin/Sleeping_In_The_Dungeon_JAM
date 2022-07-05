using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMove : MonoBehaviour
{
    // ���������� � �������� �������� �� ����� ��� ��������
    [SerializeField] private Vector3 pointToMove;
    public Vector3 GetPointToMove() => pointToMove;
    public void SetPointToMove(Vector3 point) => pointToMove = point;

    // ���������� � �������� �������� �� ����� ������� ��� ����������� ��������
    private Premises nextRoom;
    public Premises GetNextRoom() => nextRoom;
    public void SetNextRoom(Premises room) => nextRoom = room;
}
