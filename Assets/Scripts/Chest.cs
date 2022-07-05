using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private Animator anim_Chest;
    private bool isOpen = false;

    private void Start()
    {
        anim_Chest = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        if(!isOpen)
        {
            anim_Chest.SetBool("isOpen", true);
            isOpen = true;
        }
        else
        {
            anim_Chest.SetBool("isOpen", false);
            isOpen = false;
        }    
    }
}
