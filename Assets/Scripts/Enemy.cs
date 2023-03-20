using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    bool isfired = false;
    [SerializeField] private float timeInterval = 2f;
    [SerializeField] private Transform enemyFirePoint;

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
        if (bullet != null)
        {
            bullet.transform.position = enemyFirePoint.position;
            bullet.transform.rotation = enemyFirePoint.rotation;
            bullet.SetActive(true);
        }
        isfired = false;
    }

}
