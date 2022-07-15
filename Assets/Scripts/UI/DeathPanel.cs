using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private const string winText_RU = "Конец?";
    private const string winText_EN = "The End?";
    private const string DeathText_RU = "Вы мертвы";
    private const string DeathText_EN = "You Dead";

    private void Start()
    {
        if (GameController.GetInstance().GetValue_IsWin())
        {
            if (LanguageController.GetLanguage() == (int)ListLanguage.English)
            {
                text.text = winText_EN;
            }

            if (LanguageController.GetLanguage() == (int)ListLanguage.Russian)
            {
                text.text = winText_RU;
            }
        }
        else
        {
            if (LanguageController.GetLanguage() == (int)ListLanguage.English)
            {
                text.text = DeathText_EN;
            }

            if (LanguageController.GetLanguage() == (int)ListLanguage.Russian)
            {
                text.text = DeathText_RU;
            }
        }
    }

    public void RestartLevel()
    {
        GameController.GetInstance().SwitchAllowedRay(false);
        SceneManager.LoadScene("Level");
    }
}
