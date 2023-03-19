using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    //[SerializeField] private GameObject bulletPrefab;
    bool isFired = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&&isFired)
        {
            StartCoroutine(Fire());
            isFired = false;          
        }
    }
    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(.3f);
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(.5f);
        isFired = true;

    }
}
