using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuPanel : MonoBehaviour
{
    private const string buttonContinueText_RU = "Продолжить";
    private const string buttonContinueText_EN = "Continue";
    private const string buttonExitText_RU = "Выход";
    private const string buttonExitText_EN = "Exit";
    private const string textMenu_RU = "Меню";
    private const string textMenu_EN = "Menu";

    [SerializeField] private Button buttonContinue, buttonExit;
    [SerializeField] private TextMeshProUGUI textMenu;

    private void Start()
    {
        Language(LanguageController.GetLanguage());

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
        SceneManager.LoadScene("MainMenu");
    }

    private void Language(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            textMenu.text = textMenu_EN;
            buttonContinue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonContinueText_EN;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_EN;
        }

        if (language == (int)ListLanguage.Russian)
        {
            textMenu.text = textMenu_RU;
            buttonContinue.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonContinueText_RU;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_RU;
        }
    }
}
