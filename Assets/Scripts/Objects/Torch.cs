using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ObjectManager
{
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] Light lightFlame;
    private bool isFlame;
    private int countFlame = 1;

    private void Start()
    {
        if (this.gameObject.name == "TorchRoom_1_Right" || this.gameObject.name == "TorchRoom_1_Left")
        {
            lightFlame.enabled = false;
            isFlame = false;
        }
        else
        {
            isFlame = true;
        }
    }

    public override void InteractionWithPlayer()
    {
        if (!isFlame)
        {
            ps_Flame.Play();
            lightFlame.enabled = true;
            isFlame = true;

            if (this.gameObject.name == "TorchRoom_1_Right" || this.gameObject.name == "TorchRoom_1_Left")
            {
                GameController.GetInstance().CounterFlameRoom_1(countFlame);
            }
        }
        else
        {
            ps_Flame.Stop();
            lightFlame.enabled = false;
            isFlame = false;

            if (this.gameObject.name == "TorchRoom_1_Right" || this.gameObject.name == "TorchRoom_1_Left")
            {
                GameController.GetInstance().CounterFlameRoom_1(-countFlame);
            }
        }
    }
}
