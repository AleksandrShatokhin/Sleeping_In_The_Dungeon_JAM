using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteController : MonoBehaviour
{
    private StreamReader note;

    private string pathToNoteRoom_1_RU = Application.streamingAssetsPath + "/NoteRoom_1_RU" + ".txt";
    private string pathToNoteRoom_3_RU = Application.streamingAssetsPath + "/NoteRoom_3_RU" + ".txt";
    private string pathToNoteRoom_5_RU = Application.streamingAssetsPath + "/NoteRoom_5_RU" + ".txt";
    private string pathToNoteRoom_7_RU = Application.streamingAssetsPath + "/NoteRoom_7_RU" + ".txt";
    private string pathToNoteRoom_8_RU = Application.streamingAssetsPath + "/NoteRoom_8_RU" + ".txt";

    private string pathToNoteRoom_1_EN = Application.streamingAssetsPath + "/NoteRoom_1_EN" + ".txt";
    private string pathToNoteRoom_3_EN = Application.streamingAssetsPath + "/NoteRoom_3_EN" + ".txt";
    private string pathToNoteRoom_5_EN = Application.streamingAssetsPath + "/NoteRoom_5_EN" + ".txt";
    private string pathToNoteRoom_7_EN = Application.streamingAssetsPath + "/NoteRoom_7_EN" + ".txt";
    private string pathToNoteRoom_8_EN = Application.streamingAssetsPath + "/NoteRoom_8_EN" + ".txt";

    private int currentNumberNote;
    private string currentTextNote;

    public void SetCurrentNumberNote(int id) => currentNumberNote = id;

    public string GetCurrentTextNote()
    {
        if (LanguageController.GetLanguage() == (int)ListLanguage.English)
        {
            switch (currentNumberNote)
            {
                case 1:
                    note = new StreamReader(pathToNoteRoom_1_EN);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 3:
                    note = new StreamReader(pathToNoteRoom_3_EN);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 5:
                    note = new StreamReader(pathToNoteRoom_5_EN);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 7:
                    note = new StreamReader(pathToNoteRoom_7_EN);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 8:
                    note = new StreamReader(pathToNoteRoom_8_EN);
                    currentTextNote = note.ReadToEnd();
                    break;
            }
        }

        if (LanguageController.GetLanguage() == (int)ListLanguage.Russian)
        {
            switch (currentNumberNote)
            {
                case 1:
                    note = new StreamReader(pathToNoteRoom_1_RU);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 3:
                    note = new StreamReader(pathToNoteRoom_3_RU);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 5:
                    note = new StreamReader(pathToNoteRoom_5_RU);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 7:
                    note = new StreamReader(pathToNoteRoom_7_RU);
                    currentTextNote = note.ReadToEnd();
                    break;

                case 8:
                    note = new StreamReader(pathToNoteRoom_8_RU);
                    currentTextNote = note.ReadToEnd();
                    break;
            }
        }

        return currentTextNote;
    }
}
