using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picture : ObjectManager
{
    private Animator anim_Picture;

    [SerializeField] private AudioClip audioOpen;
    public void PlayAudioOpenPicture() => GameController.GetInstance().PlayAudio(audioOpen);

    [SerializeField] private GameObject picturePanel, pictureItemPanel;
    private bool isOpenPicture;
    public bool isPlayerTakeItem { get; private set; }
    public void SwitchIsPlayerTakeItem() => isPlayerTakeItem = true;

    private void Start()
    {
        anim_Picture = GetComponent<Animator>();
        isPlayerTakeItem = false;
    }

    public void SwitchIsOpenPicture()
    {
        isOpenPicture = true;
        anim_Picture.SetTrigger("isOpen");
    }

    public override void InteractionWithPlayer()
    {
        if (!isOpenPicture)
        {
            Instantiate(picturePanel, picturePanel.transform.position, picturePanel.transform.rotation);
            GameController.GetInstance().PauseGameTimeAndMainUI(false);
        }
        else
        {
            Instantiate(pictureItemPanel, pictureItemPanel.transform.position, pictureItemPanel.transform.rotation);
            GameController.GetInstance().PauseGameTimeAndMainUI(false);
        }
    }
}
