using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField] AudioManager audioManager;
    bool isFinished = false;
    private void Start()
    {
        gameManager=FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&!isFinished)
        {
            Debug.Log("Game Won");
            audioManager.WinSound();
            isFinished = true;
            StartCoroutine(GameFinished());
        }
    }
    private IEnumerator GameFinished()
    {
        yield return new WaitForSeconds(1);
        gameManager.GameWon();
    }
}
