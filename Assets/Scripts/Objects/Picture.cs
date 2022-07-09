using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : ObjectManager
{
    [SerializeField] private GameObject picturePanel;

    public override void InteractionWithPlayer()
    {
        Instantiate(picturePanel, picturePanel.transform.position, picturePanel.transform.rotation);
        GameController.GetInstance().PauseGameTimeAndMainUI(false);
    }
}
