using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public Vector3 offset;
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x,player.position.y,0)+ offset;
    }
}
