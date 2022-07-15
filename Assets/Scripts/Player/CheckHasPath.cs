using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CheckHasPath : MonoBehaviour
{
    private Animator animator_Player;
    private NavMeshAgent agent_Player;

    [SerializeField] private AudioClip audioStep;

    void Start()
    {
        animator_Player = GetComponent<Animator>();
        agent_Player = GetComponentInParent<NavMeshAgent>();
    }

    public void Check()
    {
        if (!agent_Player.hasPath)
        {
            animator_Player.SetBool("isRun", false);
        }
    }

    public void Step()
    {
        GameController.GetInstance().PlayAudio(audioStep, 0.1f);
    }
}
