using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ObjectManager
{
    private Animator anim_Door;
    public bool doorIsOpen { get; private set; } = false;
    private const string messageForPlayer = "Так дверь не открыть!";

    [SerializeField] private AudioClip audioOpenDoor, audioCloseDoor;
    public void PlayAudioOpenDoor() => GameController.GetInstance().PlayAudio(audioOpenDoor);
    public void PlayAudioCloseDoor() => GameController.GetInstance().PlayAudio(audioCloseDoor);

    private void Start()
    {
        anim_Door = GetComponent<Animator>();
    }

    public void OpenDoor(bool isOpen)
    {
        anim_Door.SetBool("isOpen", isOpen);
        doorIsOpen = isOpen;
    }

    public override void InteractionWithPlayer()
    {
        if (!doorIsOpen)
        {
            GameController.GetInstance().OutputMessageForPlayer(messageForPlayer);
        }
    }
}
