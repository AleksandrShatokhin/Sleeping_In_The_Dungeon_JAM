using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryItems
{
    public abstract void Use();
}

public class Blade : InventoryItems
{
    public override void Use()
    {
        GameController.GetInstance().GetPlayerController().BladeActive();
    }
}