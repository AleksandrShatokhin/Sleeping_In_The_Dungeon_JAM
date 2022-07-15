using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PictureItemPanel : MonoBehaviour
{
    private const string buttonExitText_RU = "Выход";
    private const string buttonExitText_EN = "Exit";

    [SerializeField] Button buttonExit;
    [SerializeField] Button buttonItem;

    [SerializeField] private AudioClip audioUseItem;

    private Image iconItem;

    private void Start()
    {
        LanguageButtons(LanguageController.GetLanguage());

        GameController.GetInstance().SwitchAllowedRay(false);

        buttonExit.onClick.AddListener(Exit);
        buttonItem.onClick.AddListener(TakeItem);

        iconItem = buttonItem.transform.GetChild(0).GetComponent<Image>();

        if (GameController.GetInstance().GetPictureComponent().isPlayerTakeItem)
        {
            iconItem.sprite = null;
        }
    }

    private void TakeItem()
    {
        GameController.GetInstance().GetInventory().GetComponent<Inventory>().SetItemInCell(iconItem.sprite);
        iconItem.sprite = null;
        GameController.GetInstance().GetPictureComponent().SwitchIsPlayerTakeItem();
        GameController.GetInstance().PlayAudio(audioUseItem);
    }

    private void Exit()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().SwitchAllowedRay(true);
    }

    private void LanguageButtons(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_EN;
        }

        if (language == (int)ListLanguage.Russian)
        {
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_RU;
        }
    }
}
