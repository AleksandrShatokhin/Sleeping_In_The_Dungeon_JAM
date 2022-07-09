using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PicturePanel : MonoBehaviour
{
    [SerializeField] private Button button_1, button_2, button_3, button_4, button_5, button_6, button_7, button_8;
    [SerializeField] private Button buttonVerify, buttonClose;

    [SerializeField] private GameObject fieldPassword;
    [SerializeField] private TextMeshProUGUI[] textPassword;

    private const string tryPassword = "12345678";
    private string currentPassword = "";

    void Start()
    {
        buttonVerify.onClick.AddListener(VerifyPassword);
        buttonClose.onClick.AddListener(ClosePanel);

        ResetTextPasword();
    }

    private void ResetTextPasword()
    {
        for (int i = 0; i < textPassword.Length; i++)
        {
            textPassword[i].text = null;
        }
    }

    // вызываю как событие на каждой кнопке в редакторе
    public void ClickButton(GameObject go)
    {
        TextMeshProUGUI textComponent = go.GetComponentInChildren<TextMeshProUGUI>();

        for (int i = 0; i < textPassword.Length; i++)
        {
            if (textPassword[i].text == null)
            {
                textPassword[i].text = textComponent.text;
                currentPassword += textComponent.text;
                return;
            }
        }
    }

    private void VerifyPassword()
    {
        if (currentPassword == tryPassword)
        {
            Debug.Log("Правильные пароль");
        }
        else
        {
            ResetTextPasword();
            currentPassword = "";
            Debug.Log("Неверный пароль");
        }
    }

    private void ClosePanel()
    {
        GameController.GetInstance().CloseUIPanel();
    }
}
