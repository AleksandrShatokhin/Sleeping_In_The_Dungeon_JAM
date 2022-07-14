using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeakPanel : MonoBehaviour
{
    [SerializeField] private Button buttonClose;

    void Start()
    {
        buttonClose.onClick.AddListener(CloseSpeakPanel);
    }

    private void CloseSpeakPanel()
    {
        GameController.GetInstance().CloseUIPanel();
    }
}
