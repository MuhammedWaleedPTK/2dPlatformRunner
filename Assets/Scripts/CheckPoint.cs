using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerLIfe playerlife;
    bool isCheckPoint = true;
    AudioManager audioManager;
    private void Start()
    {
        playerlife=FindObjectOfType<PlayerLIfe>();
        audioManager=FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"&&isCheckPoint)
        {
            playerlife.startPosition=gameObject.transform.position;
            isCheckPoint=false;
            audioManager.WinSound();
        }
    }
}
