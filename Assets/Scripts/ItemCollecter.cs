using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemCollecter : MonoBehaviour
{
    int collected = 0;
    [SerializeField] private TextMeshProUGUI score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collected++;
            Debug.Log("Collected:"+collected.ToString());
            score.text = "Collected:" + collected.ToString();
            Destroy(collision.gameObject);
        }
    }
}
