using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ObjectManager
{
    [SerializeField] private int numberTorch;
    public int GetNumberTorch() => numberTorch;

    [SerializeField] private AudioClip audioFlame, audioFlameOff;

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
            GameController.GetInstance().PlayAudio(audioFlame);

            if (this.gameObject.name == "TorchRoom_1_Right" || this.gameObject.name == "TorchRoom_1_Left")
            {
                GameController.GetInstance().CounterFlameRoom_1(countFlame);
            }

            if (numberTorch == 2)
            {
                GameController.GetInstance().CounterFlameRoom_9(countFlame);
            }
        }
        else
        {
            ps_Flame.Stop();
            lightFlame.enabled = false;
            isFlame = false;
            GameController.GetInstance().PlayAudio(audioFlameOff);

            if (this.gameObject.name == "TorchRoom_1_Right" || this.gameObject.name == "TorchRoom_1_Left")
            {
                GameController.GetInstance().CounterFlameRoom_1(-countFlame);
            }

            if (numberTorch == 2)
            {
                GameController.GetInstance().CounterFlameRoom_9(-countFlame);
            }
        }
    }
}
