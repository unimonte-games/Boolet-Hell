﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTurret : MonoBehaviour
{
    private Vector3 firingpoint;

    private GameObject target;
    public float damage;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float maxprojectiledistance;

    void Start()
    {
        firingpoint = transform.position;
    }

    void Update()
    {
        moveprojectile();

    }

    void moveprojectile()
    {
        if (Vector3.Distance(firingpoint, transform.position) > maxprojectiledistance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * projectileSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.gameObject;
            target.GetComponent<PlayerScript>().health -= damage;
            Destroy(this.gameObject);
        }
    }
}
