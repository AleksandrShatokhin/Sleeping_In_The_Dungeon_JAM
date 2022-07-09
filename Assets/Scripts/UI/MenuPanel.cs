using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button buttonContinue, buttonInventory, buttonExit;

    private void Start()
    {
        buttonContinue.onClick.AddListener(Continue);
        buttonInventory.onClick.AddListener(CallInventory);
        buttonExit.onClick.AddListener(Exit);
    }

    private void Continue()
    {
        GameController.GetInstance().CloseUIPanel();
    }

    private void CallInventory()
    {

    }

    private void Exit()
    {

    }
}
