using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : ObjectManager
{
    [SerializeField] ChestData chestData;
    private Animator anim_Chest;
    [SerializeField] private GameObject panelPrefab;

    private void Start()
    {
        anim_Chest = GetComponent<Animator>();
    }

    public override void InteractionWithPlayer()
    {
        anim_Chest.SetBool("isOpen", true);
        StartCoroutine(CallPanel());
    }

    IEnumerator CallPanel()
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate(panelPrefab, panelPrefab.transform.position, panelPrefab.transform.rotation);
        GameController.GetInstance().GetChestController().SetCurrentIcon(chestData.iconLeft, chestData.iconRight);
        GameController.GetInstance().PauseGameTimeAndMainUI(false);
        anim_Chest.SetBool("isOpen", false);
    }
}
