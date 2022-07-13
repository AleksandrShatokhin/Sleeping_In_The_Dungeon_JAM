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

    [SerializeField] private int health;
    private bool isBlock = false;

    public bool isBladeInHand { get; private set; } = false;
    [SerializeField] private GameObject blade;
    public void BladeActive()
    {
        blade.SetActive(true);
        isBladeInHand = true;
    }

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

    public void RotatePlayerOnEnemy(Transform enemyPosition)
    {
        transform.LookAt(enemyPosition, Vector3.up);
    }

    public void Attack(FightPanel panel)
    {
        animator_Player.SetTrigger("isAttack");

        int damage = Random.Range(1, 20);
        //int damage = Random.Range(90, 100);
        panel.ChangeHealthEnemy(damage);
    }

    public void Block(bool value) => isBlock = value;
    public bool CheckIsBlock() => isBlock;

    public int GetHealthPlayer() => health;
    public void ChangeHealthPlayer(int health) => this.health += health;
}
