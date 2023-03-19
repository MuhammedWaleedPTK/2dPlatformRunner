using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    //[SerializeField] private GameObject bulletPrefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject bullet = ObjectPool.instance.GetPooledObject();
            if(bullet != null )
            {
                bullet.transform.position= firePoint.position;
                bullet.transform.rotation = firePoint.rotation;
                bullet.SetActive(true);
            }
          
        }
    }
}
