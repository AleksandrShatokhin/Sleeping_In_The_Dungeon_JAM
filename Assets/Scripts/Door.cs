using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim_Door;
    private bool doorIsOpen = false;

    private void Start()
    {
        anim_Door = GetComponent<Animator>();
    }

    public void OpenDoor(bool isOpen)
    {
        anim_Door.SetBool("isOpen", isOpen);
        doorIsOpen = isOpen;
    }

    private void OnMouseDown()
    {
        if (!doorIsOpen)
        {
            Debug.Log("Так дверь не открыть!");
        }
    }
}
