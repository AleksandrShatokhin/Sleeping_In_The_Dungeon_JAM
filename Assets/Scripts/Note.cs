using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Note : MonoBehaviour
{
    [SerializeField] private Button buttonClose;
    [SerializeField] private TextMeshProUGUI textNote;

    private void Start()
    {
        buttonClose.onClick.AddListener(CloseNote);
        textNote.text = GameController.GetInstance().GetNoteController().GetCurrentTextNote();
    }

    private void CloseNote()
    {
        GameObject note = GameObject.FindGameObjectWithTag("Note");
        Destroy(note);

        GameController.GetInstance().GetMainUI().SetActive(true);
        Time.timeScale = 1.0f;
    }
}
