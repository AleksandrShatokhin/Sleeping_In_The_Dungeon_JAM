using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Sprite iconLeft, iconRight;
    private GameObject currentChest;

    public void SetCurrentIcon(GameObject chest, Sprite iconLeft, Sprite iconRight)
    {
        currentChest = chest;

        this.iconLeft = iconLeft;
        this.iconRight = iconRight;
    }

    public Sprite GetCurrentIconLeft() => this.iconLeft;
    public Sprite GetCurrentIconRight() => this.iconRight;

    public GameObject GetCurrentChest() => currentChest;
}