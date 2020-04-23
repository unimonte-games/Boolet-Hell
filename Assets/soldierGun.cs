using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soldierGun : MonoBehaviour
{

    private GameObject target;
    private bool targetlocked;

    public GameObject bulletSpawnPoint;
    public GameObject bulletTurret;
    public float fireTimer;
    private bool shootReady;


    private void Start()
    {
        shootReady = true;
    }


    private void Update()
    {
        if (targetlocked)
        {

            if (shootReady)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bulletTurret.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        _bullet.transform.rotation = bulletSpawnPoint.transform.rotation;
        shootReady = false;
        StartCoroutine(FireRate());
    }

    IEnumerator FireRate()
    {
        yield return new WaitForSeconds(fireTimer);
        shootReady = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (target)
                targetlocked = true;
            else
                targetlocked = false;

            if (targetlocked == false)
            {
                target = other.gameObject;
            }
        }
    }

}
