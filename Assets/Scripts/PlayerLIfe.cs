using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLIfe : MonoBehaviour
{
    private Animator anim;
    Rigidbody2D rb;
    [SerializeField] private AudioManager audioManager;
    Vector3 startPosition;
    [SerializeField] private GameObject[] lifeHearts;

    private int life = 3;
    private bool isDamaged = false;

    private void Start()
    {
        anim= GetComponent<Animator>();
        rb= GetComponent<Rigidbody2D>();
        Debug.Log("Life:" + life.ToString());
        startPosition= transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("trap")&&life>0&&!isDamaged)
        {
            isDamaged=true;
            audioManager.HitSound();
            TakeDamage();
            
        }
    }
    public void TakeDamage()
    {
        life--;
        lifeHearts[life].SetActive(false);
        if (life <= 0)
        {
            Die();
            return;
        }
        Debug.Log("Life:" + life.ToString());

        StartCoroutine(ChangePosition());
    }
    private IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(0.3f);
        transform.position = startPosition;
        isDamaged= false;
    }
    private void Die()
    {
        audioManager.DeathSound();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Dead");
        
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
