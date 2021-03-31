using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndRuna : MonoBehaviour
{
    public Runas scriptRuna;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AtkBasico"))
        {
            scriptRuna.health += 2;
            Destroy(other.gameObject);
        }

    }
}
