using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private const string mainText_RU = "Инвентарь";
    private const string mainText_EN = "Inventory";

    private Animator anim_Inventory;
    [SerializeField] private Button buttonCloseInventory;
    [SerializeField] private GameObject[] cells;
    [SerializeField] private TextMeshProUGUI mainText;

    private void Start()
    {
        Language(LanguageController.GetLanguage());

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

    private void Language(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            mainText.text = mainText_EN;
        }

        if (language == (int)ListLanguage.Russian)
        {
            mainText.text = mainText_RU;
        }
    }

    // вызываю в процессе проигрывания анимации
    private void Pause_On() => GameController.GetInstance().PauseGameTimeAndMainUI(false);
}
