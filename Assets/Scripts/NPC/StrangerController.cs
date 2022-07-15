using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StrangerController : ObjectManager
{
    private NavMeshAgent agent_Stranger;
    [SerializeField] private Animator anim_Stranger;
    private const string messageForPlayer_RU = "Кажется он мертв... Возможно ему еще можно помочь...";
    private const string messageForPlayer_EN = "I think he's dead... Perhaps he can still be helped...";

    private Quaternion positionStandUp = Quaternion.Euler(0, 0, 0);
    private Vector3 positionForMove = new Vector3(5.0f, 0.0f, 20.0f);

    [SerializeField] private GameObject speakPanel;
    private bool isAlive;


    private void Start()
    {
        agent_Stranger = GetComponent<NavMeshAgent>();
        agent_Stranger.enabled = false;
        anim_Stranger.enabled = false;
        isAlive = false;
    }

    public void StrangerStandUp()
    {
        transform.rotation = positionStandUp;
        agent_Stranger.enabled = true;
        anim_Stranger.enabled = true;
        isAlive = true;
    }

    public override void InteractionWithPlayer()
    {
        if (isAlive)
        {
            Instantiate(speakPanel, speakPanel.transform.position, speakPanel.transform.rotation);
            GameController.GetInstance().PauseGameTimeAndMainUI(false);
            agent_Stranger.SetDestination(positionForMove);
            anim_Stranger.SetBool("isRun", true);
            GameController.GetInstance().GetFinalDoor().GetComponent<Door>().OpenDoor(true);
        }
        else
        {
            if (LanguageController.GetLanguage() == (int)ListLanguage.English)
            {
                GameController.GetInstance().OutputMessageForPlayer(messageForPlayer_EN);
            }

            if (LanguageController.GetLanguage() == (int)ListLanguage.Russian)
            {
                GameController.GetInstance().OutputMessageForPlayer(messageForPlayer_RU);
            }

        }
    }
}
