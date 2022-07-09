using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandWithPaper : ObjectManager
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private int id;

    //private void OnMouseDown()
    //{
    //    Instantiate(notePrefab, notePrefab.transform.position, notePrefab.transform.rotation);
    //    GameController.GetInstance().GetNoteController().SetCurrentNumberNote(id);
    //    GameController.GetInstance().PauseGameTimeAndMainUI(false);
    //}

    public override void InteractionWithPlayer()
    {
        Instantiate(notePrefab, notePrefab.transform.position, notePrefab.transform.rotation);
        GameController.GetInstance().GetNoteController().SetCurrentNumberNote(id);
        GameController.GetInstance().PauseGameTimeAndMainUI(false);
    }
}
