using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] Button buttonContinue, buttonInventory, buttonExit;

    private void Start()
    {
        buttonContinue.onClick.AddListener(Continue);
        buttonExit.onClick.AddListener(Exit);

        GameController.GetInstance().SwitchAllowedRay(false);
    }

    private void Continue()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().SwitchAllowedRay(true);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
