using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private Animator anim_Inventory;
    [SerializeField] private Button buttonCloseInventory;
    [SerializeField] private GameObject[] cells;

    private void Start()
    {
        anim_Inventory = GetComponent<Animator>();

        buttonCloseInventory.onClick.AddListener(CloseInventory);
    }

    private void CloseInventory()
    {
        GameController.GetInstance().PauseGameTimeAndMainUI(true);
        anim_Inventory.SetBool("isOpen", false);
    }

    public void SetItemInCell(Sprite iconItem)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            if (cells[i].GetComponent<CellInventory>().GetIcon() == null)
            {
                cells[i].GetComponent<CellInventory>().SetIcon(iconItem);
                return;
            }
        }
    }

    // вызываю в процессе проигрывания анимации
    private void Pause_On() => GameController.GetInstance().PauseGameTimeAndMainUI(false);
}
