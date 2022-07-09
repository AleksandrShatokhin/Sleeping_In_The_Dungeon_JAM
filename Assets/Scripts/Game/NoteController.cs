using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteController : MonoBehaviour
{
    private StreamReader note;

    private string pathToNoteRoom_1 = Application.streamingAssetsPath + "/NoteRoom_1" + ".txt";

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
        }

        return currentTextNote;
    }
}
