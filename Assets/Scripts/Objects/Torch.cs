using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : ObjectManager
{
    [SerializeField] private ParticleSystem ps_Flame;
    [SerializeField] Light lightFlame;
    private bool isFlame = false;
    private int countFlame = 1;

    private void Start()
    {
        lightFlame.enabled = false;
    }

    public override void InteractionWithPlayer()
    {
        if (!isFlame)
        {
            ps_Flame.Play();
            lightFlame.enabled = true;
            isFlame = true;
            GameController.GetInstance().CounterFlameRoom_1(countFlame);
        }
        else
        {
            ps_Flame.Stop();
            lightFlame.enabled = false;
            isFlame = false;
            GameController.GetInstance().CounterFlameRoom_1(-countFlame);
        }
    }
}
