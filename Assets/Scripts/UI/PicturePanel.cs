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

    [SerializeField] private AudioClip audioUseButton;

    private const string tryPassword = "28141327";
    private string currentPassword = "";

    void Start()
    {
        GameController.GetInstance().SwitchAllowedRay(false);

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

        GameController.GetInstance().PlayAudio(audioUseButton);
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
            ChangeButtonColor();
            GameController.GetInstance().GetPictureComponent().SwitchIsOpenPicture();
        }
        else
        {
            ResetTextPasword();
            currentPassword = "";
        }
    }

    private void ClosePanel()
    {
        GameController.GetInstance().CloseUIPanel();
        GameController.GetInstance().SwitchAllowedRay(true);
    }

    public void ChangeButtonColor()
    {
        button_1.image.color = Color.green;
        button_2.image.color = Color.green;
        button_3.image.color = Color.green;
        button_4.image.color = Color.green;
        button_5.image.color = Color.green;
        button_6.image.color = Color.green;
        button_7.image.color = Color.green;
        button_8.image.color = Color.green;
    }
}
