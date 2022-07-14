using UnityEngine;
using UnityEngine.UI;

public class PictureItemPanel : MonoBehaviour
{
    [SerializeField] Button buttonExit;
    [SerializeField] Button buttonItem;

    private Image iconItem;

    private void Start()
    {
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
    }

    private void Exit()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().SwitchAllowedRay(true);
    }
}
