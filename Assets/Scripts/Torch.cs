using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps_Flame;
    private bool isFlame = false;
    private int countFlame = 1;

    private void OnMouseDown()
    {
        if (!isFlame)
        {
            ps_Flame.Play();
            isFlame = true;
            GameController.GetInstance().CounterFlameRoom_1(countFlame);
        }
        else
        {
            ps_Flame.Stop();
            isFlame = false;
            GameController.GetInstance().CounterFlameRoom_1(-countFlame);
        }
    }
}
