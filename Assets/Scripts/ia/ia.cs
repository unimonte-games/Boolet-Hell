using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ia : MonoBehaviour
{
    NavMeshAgent Esqueleto;
    Transform Jogador;
    public float Argodist,Tirodist,time,cadencia, forcaTiro;
    public GameObject Osso;
    public Transform Maodoarremeco;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Esqueleto = GetComponent<NavMeshAgent>();
        Jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Jogador.position);
        if (distance <= Argodist )
        {
            Esqueleto.destination = Jogador.position;
            if (distance <= Tirodist)
            {
                Esqueleto.isStopped = true;
                transform.LookAt(Jogador);
                time += Time.deltaTime;
                if (time >= cadencia)
                {
                   
                    var osso = Instantiate(Osso, Maodoarremeco.position, Maodoarremeco.rotation);
                    var rb = osso.GetComponent<Rigidbody>();
                    rb.AddForce(transform.forward * forcaTiro, ForceMode.Force);
                    time = 0;
                    
                }
            }
            else
            {
                time = 0;
                Esqueleto.isStopped = false;
            }

        }

    }
}
