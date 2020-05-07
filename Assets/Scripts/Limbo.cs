using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limbo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // show
            gameObject.GetComponent<Renderer>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            // hide
            gameObject.GetComponent<Renderer>().enabled = false;
        }
    }
}
