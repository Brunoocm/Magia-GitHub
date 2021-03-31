using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropável : MonoBehaviour
{
    public string tipo;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (tipo == "olho") Combinacoes.olho++;
            else if (tipo == "gosma") Combinacoes.gosma++;
            else if (tipo == "lagrima") Combinacoes.lagrima++;
            Destroy(gameObject);
        }
    }
}
