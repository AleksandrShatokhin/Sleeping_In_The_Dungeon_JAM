using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandWithPaper : MonoBehaviour
{
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private int id;

    private void OnMouseDown()
    {
        Instantiate(notePrefab, notePrefab.transform.position, notePrefab.transform.rotation);
        GameController.GetInstance().GetNoteController().SetCurrentNumberNote(id);
        GameController.GetInstance().GetMainUI().SetActive(false);
        Time.timeScale = 0.0f;
    }
}
