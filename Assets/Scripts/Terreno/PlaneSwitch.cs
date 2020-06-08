using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSwitch : MonoBehaviour
{
    [SerializeField] private bool isLimbo;
    private Renderer _renderer;
    private Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
        _collider = GetComponent<Collider>();

        ChangePlane();
    }

    // Update is called once per frame
    void Update()
    { 

        ChangePlane();

    }

    private void ChangePlane()
    {

        var value = ((isLimbo && Playercontroller.plane) || (!isLimbo && !Playercontroller.plane));

        _renderer.enabled = value;
        _collider.enabled = value;

    }
}