using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {
    private Vector3 firingpoint;

    [SerializeField]
    private float projectileSpeed;

    [SerializeField]
    private float maxprojectiledistance;

    void Start () {
        firingpoint = transform.position;
	}
	
	void Update () {
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
}
