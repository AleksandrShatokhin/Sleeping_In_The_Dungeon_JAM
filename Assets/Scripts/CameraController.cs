using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform targetPlayer;
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - targetPlayer.position;
    }

    private void LateUpdate()
    {
        transform.position = targetPlayer.position + offset;
    }
}
