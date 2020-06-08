﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trocadearma : MonoBehaviour
{
    public GameObject[] listaArmas;
    int armaAtual;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Trocar();
        }


    }

    void Trocar()
    {
        armaAtual = (armaAtual + 1) % listaArmas.Length;

        for (int i = 0; i < listaArmas.Length; i++)
        {
            if (i != armaAtual)
            {
                listaArmas[i].SetActive(false);
            }
            else
            {
                listaArmas[i].SetActive(true);
            }
        }
    }
}
