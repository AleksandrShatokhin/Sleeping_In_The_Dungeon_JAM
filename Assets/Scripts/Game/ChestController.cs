using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController : MonoBehaviour
{
    private Sprite iconLeft, iconRight;
    public void SetCurrentIcon(Sprite iconLeft, Sprite iconRight)
    {
        this.iconLeft = iconLeft;
        this.iconRight = iconRight;
    }

    public Sprite GetCurrentIconLeft() => this.iconLeft;
    public Sprite GetCurrentIconRight() => this.iconRight;
}
