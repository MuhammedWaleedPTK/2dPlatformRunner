using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isfired = false;
    [SerializeField] private float timeInterval = 2f;
    [SerializeField] private Transform enemyFirePoint;
    Animator anim;
    bool isAlive = true;
    WayPointFollower follower;

    private void Start()
    {
        anim = GetComponent<Animator>();
        follower = GetComponent<WayPointFollower>();
    }
    private void Update()
    {
        if (!isfired)
        {
            StartCoroutine(EnemyFire());
            isfired = true;
        }
     
        
    }

    private IEnumerator EnemyFire()
    {
        yield return new WaitForSeconds(timeInterval);
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null&&isAlive)
        {
            bullet.transform.position = enemyFirePoint.position;
            bullet.transform.rotation = enemyFirePoint.rotation;
            bullet.SetActive(true);
        }
        isfired = false;
    }
    public IEnumerator EnemyDied()
    {
        isAlive = false;
        if (follower != null)
        {
            follower.enabled = false;
        }
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(2f);
        gameObject.SetActive(false);
    }

}
