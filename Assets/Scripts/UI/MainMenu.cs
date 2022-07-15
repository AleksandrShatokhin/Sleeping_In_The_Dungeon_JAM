using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button buttonStart, buttonExit;
    private const string buttonStartText_RU = "����� ����";
    private const string buttonStartText_EN = "Start Game";
    private const string buttonExitText_RU = "�����";
    private const string buttonExitText_EN = "Exit";

    [SerializeField] private Button buttonSwitcherLanguage;
    private int language = 1;
    private const string buttonSwitcherLanguageText_RU = "�������";
    private const string buttonSwitcherLanguageText_EN = "English";

    void Start()
    {
        buttonStart.onClick.AddListener(StartGame);
        buttonExit.onClick.AddListener(Exit);
        buttonSwitcherLanguage.onClick.AddListener(SwitcherLanguage);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Level");
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void SwitcherLanguage()
    {
        // ������������ �� �������
        if (language == (int)ListLanguage.English)
        {
            language = (int)ListLanguage.Russian;
            buttonSwitcherLanguage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonSwitcherLanguageText_RU;
            buttonStart.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonStartText_RU;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_RU;
            LanguageController.ChangeLanguage(language);
            return;
        }

        // ������������ �� ����������
        if (language == (int)ListLanguage.Russian)
        {
            language = (int)ListLanguage.English;
            buttonSwitcherLanguage.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonSwitcherLanguageText_EN;
            buttonStart.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonStartText_EN;
            buttonExit.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = buttonExitText_EN;
            LanguageController.ChangeLanguage(language);
            return;
        }
    }
}
