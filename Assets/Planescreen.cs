using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Planescreen : MonoBehaviour
{
    [SerializeField] private Image frame;
    [SerializeField] private Image bG;
    [SerializeField] private Color colorFrameLimbo, colorFrameHell;
    [SerializeField] private Color colorbGLimbo, colorbGHell;

    // Update is called once per frame
    void Update()
    {
        frame.color = (!Playercontroller.plane) ? colorFrameLimbo : colorFrameHell;
        bG.color = (!Playercontroller.plane) ? colorbGLimbo : colorbGHell;

        //Codigo acima é o mesmo de baixo optmizado
        /*if (!Playercontroller.plane)
        { 
            frame.color = colorFrameLimbo;
            bG.color = colorbGLimbo;
        }    
        else
        {
            frame.color = colorFrameHell;
            bG.color = colorbGHell;
        }*/
    }
}
