using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
     public int collected = 0;
    [SerializeField] private TextMeshProUGUI score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
           AudioSource audioSource=collision.gameObject.GetComponent<AudioSource>();
            SpriteRenderer spriteRenderer=collision.gameObject.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider=collision.gameObject.GetComponent<BoxCollider2D>();
            audioSource.Play();
            collected++;
            Debug.Log("Collected:"+collected.ToString());
            score.text = collected.ToString();
            boxCollider.enabled = false;
            spriteRenderer.enabled = false;
            
        }
    }
}
