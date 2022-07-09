using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellInventory : Inventory
{
    [SerializeField] private Image icon;

    private void Start()
    {
        icon.sprite = null;
    }

    public Sprite GetIcon() => icon.sprite;
    public void SetIcon(Sprite sprite) => icon.sprite = sprite;
}
