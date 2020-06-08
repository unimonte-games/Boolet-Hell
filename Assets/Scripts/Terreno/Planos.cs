using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planos : MonoBehaviour
{
    BoxCollider ColliderLimbo1;
    BoxCollider ColliderLimbo2;
    BoxCollider ColliderHell1;
    BoxCollider ColliderHell2;

    void Start()
    {
        ColliderLimbo1 = GameObject.Find("Limbo1").GetComponent<BoxCollider>();
        ColliderLimbo2 = GameObject.Find("Limbo2").GetComponent<BoxCollider>();
        ColliderHell1 = GameObject.Find("Hell1").GetComponent<BoxCollider>();
        ColliderHell2 = GameObject.Find("Hell2").GetComponent<BoxCollider>();

        ColliderHell1.enabled = false;
        ColliderHell2.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)){
            ColliderLimbo1.enabled = false;
            ColliderLimbo2.enabled = false;
            ColliderHell1.enabled = true;
            ColliderHell2.enabled = true;
        } else if (Input.GetKeyDown(KeyCode.E)) {
            ColliderLimbo1.enabled = true;
            ColliderLimbo2.enabled = true;
            ColliderHell1.enabled = false;
            ColliderHell2.enabled = false;
        }
    }
}

