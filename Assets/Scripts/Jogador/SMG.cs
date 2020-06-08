using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : MonoBehaviour
{
    [SerializeField]
    Transform firingPoint1;

    [SerializeField]
    GameObject projectilePrefab1;

    [SerializeField]
    float firingSpeed1;

    public static SMG Instance;

    private float lasttimeshoot1 = 0;

    // Use this for initialization
    void Awake()
    {
        Instance = GetComponent<SMG>();
    }

    public void Shoot()
    {
        if (lasttimeshoot1 + firingSpeed1 <= Time.time)
        {
            lasttimeshoot1 = Time.time;
            Instantiate(projectilePrefab1, firingPoint1.position, firingPoint1.rotation);
        }
    }
}
