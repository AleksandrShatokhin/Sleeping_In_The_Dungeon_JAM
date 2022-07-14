using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ObjectManager
{
    [SerializeField] ChestData chestData;
    private Animator anim_Chest;
    [SerializeField] private GameObject panelPrefab;

    private bool isLeftCellNull = false, isRightCellNull = false;
    public void ChangeIsLeftCellNull() => isLeftCellNull = true;
    public void ChangeIsRightCellNull() => isRightCellNull = true;

    [SerializeField] private AudioClip audioOpenChest, audioCloseChest;
    public void PlayAudioOpenChest() => GameController.GetInstance().PlayAudio(audioOpenChest);
    public void PlayAudioCloseChest() => GameController.GetInstance().PlayAudio(audioCloseChest);


    private void Start()
    {
        anim_Chest = GetComponent<Animator>();
    }

    public override void InteractionWithPlayer()
    {
        anim_Chest.SetBool("isOpen", true);
        GameController.GetInstance().TurnOffMainUI();
        StartCoroutine(CallPanel());
    }

    IEnumerator CallPanel()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(panelPrefab, panelPrefab.transform.position, panelPrefab.transform.rotation);
        TransferInformationOnCell();
        GameController.GetInstance().PauseGameTimeAndMainUI(false);
        anim_Chest.SetBool("isOpen", false);
    }

    private void TransferInformationOnCell()
    {
        if (isLeftCellNull && isRightCellNull)
        {
            GameController.GetInstance().GetChestController().SetCurrentIcon(this.gameObject, null, null);
        }

        if (isLeftCellNull && !isRightCellNull)
        {
            GameController.GetInstance().GetChestController().SetCurrentIcon(this.gameObject, null, chestData.iconRight);
        }

        if (!isLeftCellNull && isRightCellNull)
        {
            GameController.GetInstance().GetChestController().SetCurrentIcon(this.gameObject, chestData.iconLeft, null);
        }    

        if (!isLeftCellNull && !isRightCellNull)
        {
            GameController.GetInstance().GetChestController().SetCurrentIcon(this.gameObject, chestData.iconLeft, chestData.iconRight);
        }
    }
}
