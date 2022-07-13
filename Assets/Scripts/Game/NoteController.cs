using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteController : MonoBehaviour
{
    private StreamReader note;

    private string pathToNoteRoom_1 = Application.streamingAssetsPath + "/NoteRoom_1" + ".txt";
    private string pathToNoteRoom_3 = Application.streamingAssetsPath + "/NoteRoom_3" + ".txt";
    private string pathToNoteRoom_5 = Application.streamingAssetsPath + "/NoteRoom_5" + ".txt";
    private string pathToNoteRoom_7 = Application.streamingAssetsPath + "/NoteRoom_7" + ".txt";
    private string pathToNoteRoom_8 = Application.streamingAssetsPath + "/NoteRoom_8" + ".txt";

    private int currentNumberNote;
    private string currentTextNote;

    public void SetCurrentNumberNote(int id) => currentNumberNote = id;

    public string GetCurrentTextNote()
    {
        switch (currentNumberNote)
        {
            case 1:
                note = new StreamReader(pathToNoteRoom_1);
                currentTextNote = note.ReadToEnd();
                break;

            case 3:
                note = new StreamReader(pathToNoteRoom_3);
                currentTextNote = note.ReadToEnd();
                break;

            case 5:
                note = new StreamReader(pathToNoteRoom_5);
                currentTextNote = note.ReadToEnd();
                break;

            case 7:
                note = new StreamReader(pathToNoteRoom_7);
                currentTextNote = note.ReadToEnd();
                break;

            case 8:
                note = new StreamReader(pathToNoteRoom_8);
                currentTextNote = note.ReadToEnd();
                break;
        }

        return currentTextNote;
    }
}
