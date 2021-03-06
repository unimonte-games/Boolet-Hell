﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeScript : MonoBehaviour
{
    [HideInInspector] public float health;
    public float maxHp;
    private void Awake()
    {
        health = maxHp;
    }

    public void Update()
    {
        if (health <= 0)
            Die();
    }

    public void Die()
    {
        print("Oh nooo" + this.gameObject.name + " morreu");
        Destroy(this.gameObject);
    }
}
