using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb_Player;
    private NavMeshAgent agent_Player;
    private Animator animator_Player;
    private SwitcherRoom switcherRoom = new SwitcherRoom();

    private void Start()
    {
        rb_Player = GetComponent<Rigidbody>();
        agent_Player = GetComponent<NavMeshAgent>();
        animator_Player = GetComponentInChildren<Animator>();

        switcherRoom.Init(GameController.GetInstance().roomController.room_1);
    }

    public void Movement(Vector3 pointForMove, Premises nextRoom)
    {
        agent_Player.SetDestination(pointForMove);
        switcherRoom.ChangeRoom(nextRoom);
    }
}
