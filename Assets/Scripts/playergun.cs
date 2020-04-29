using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playergun : MonoBehaviour {
    [SerializeField]
    Transform firingPoint;

    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    float firingSpeed;

    public static playergun Instance;

    private float lasttimeshoot = 0;

    // Use this for initialization
    void Awake () {
        Instance = GetComponent<playergun>();
	}
	
    public void Shoot()
    {
        if (lasttimeshoot + firingSpeed <= Time.time)
        {
            lasttimeshoot = Time.time;
            Instantiate(projectilePrefab, firingPoint.position, firingPoint.rotation);
        }
    }
}
