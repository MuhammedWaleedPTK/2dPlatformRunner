using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    bool isFinished = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!isFinished)
        {
            Debug.Log("Game Won");
            audioManager.WinSound();
            isFinished = true;
        }
    }
}
