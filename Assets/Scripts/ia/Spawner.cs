using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Skeleton;
    public GameObject Zombie;
    public GameObject Spirit;
    private GameObject target;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            target = other.gameObject;
            Instantiate(Skeleton);
            Instantiate(Zombie);
            Instantiate(Spirit);
            Destroy(this.gameObject);
        }
    }
}
