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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InteractionWithObjects();
        }
    }

    public void Movement(Vector3 pointForMove, Premises nextRoom)
    {
        agent_Player.SetDestination(pointForMove);
        switcherRoom.ChangeRoom(nextRoom);
    }

    public void InteractionWithObjects()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 15))
        {
            if (GameController.GetInstance().IsPauseGameTime())
            {
                return;
            }

            if (hit.transform.gameObject.layer == 3)
            {
                hit.transform.gameObject.GetComponent<ObjectManager>().InteractionWithPlayer();
            }
        }
    }
}
