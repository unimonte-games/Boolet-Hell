using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{

    private GameObject target;
    private bool targetlocked;

    public GameObject TurretTopPart;


    private void Update()
    {
        if (targetlocked)
        {
            TurretTopPart.transform.LookAt(target.transform);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            targetlocked = true;
        }
    }

}
