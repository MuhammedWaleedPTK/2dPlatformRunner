using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
     private PlayerLIfe playerLife;
    Rigidbody2D rb;
    public float speed = 2f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        playerLife = FindObjectOfType<PlayerLIfe>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rb.velocity=transform.right*speed;
        if (Vector2.Distance(player.transform.position, transform.position) > 30f)
        {
            BulletDeactivation();
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerLife.TakeDamage();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
        }

        BulletDeactivation();
    }
    void BulletDeactivation()
    {
        gameObject.SetActive(false);
    }
}
