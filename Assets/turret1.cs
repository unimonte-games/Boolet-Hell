using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{

    private GameObject target;
    private bool targetlocked;

    public GameObject turretTopPart;
    public GameObject bulletSpawnPoint;
    public GameObject bullet;
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
            turretTopPart.transform.LookAt(target.transform);
            turretTopPart.transform.Rotate (0, 180, 0);

            if (shootReady)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Transform _bullet = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
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

            if(targetlocked == false)
            {
                target = other.gameObject;
            }
        }
    }

}
