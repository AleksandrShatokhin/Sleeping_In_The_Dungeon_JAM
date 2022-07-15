using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakPanel : MonoBehaviour
{
    private string pathToSpeak_RU = Application.streamingAssetsPath + "/Speak_RU" + ".txt";
    private string pathToSpeak_EN = Application.streamingAssetsPath + "/Speak_EN" + ".txt";

    private StreamReader text;
    [SerializeField] private TextMeshProUGUI currentText;

    [SerializeField] private Button buttonClose;

    void Start()
    {
        Language(LanguageController.GetLanguage());

        buttonClose.onClick.AddListener(CloseSpeakPanel);
    }

    private void CloseSpeakPanel()
    {
        GameController.GetInstance().CloseUIPanel();
    }

    private void Language(int language)
    {
        if (language == (int)ListLanguage.English)
        {
            text = new StreamReader(pathToSpeak_EN);
            currentText.text = text.ReadToEnd();
        }

        if (language == (int)ListLanguage.Russian)
        {
            text = new StreamReader(pathToSpeak_RU);
            currentText.text = text.ReadToEnd();
        }
    }
}
