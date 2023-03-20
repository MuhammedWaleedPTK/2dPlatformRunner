using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private AudioManager audioManager;
    //[SerializeField] private GameObject bulletPrefab;
    bool isFired = true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&&isFired)
        {
            StartCoroutine(Fire());
            isFired = false;          
        }
    }
    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(.3f);
        audioManager.FireSound();
        GameObject bullet = ObjectPool.instance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
        }
        yield return new WaitForSeconds(.2f);
        isFired = true;

    }
}
