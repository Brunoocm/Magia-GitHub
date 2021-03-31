using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magosFake : MonoBehaviour
{
    public Transform guerreiro;
    public Transform guerreiroFake;

    public Transform ferreiro;
    public Transform ferreiroFake;

    public Transform alquimista;
    public Transform alquimistaFake;


    void Update()
    {
        guerreiroFake.position = guerreiro.position;
        ferreiroFake.position = ferreiro.position;
        alquimistaFake.position = alquimista.position;
    }
}
