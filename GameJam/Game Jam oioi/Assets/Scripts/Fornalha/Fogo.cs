using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fogo : MonoBehaviour
{
    public float distance;
    public float dano;
    public Transform laser;
    public LineRenderer line;
    Transform mira;
    void Start()
    {
        mira = GetComponent<Transform>();   
    }

    void Update()
    {
        if (CraftAlquimista.minigameAtivo)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(Physics2D.Raycast(mira.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(laser.position, transform.right);

            line.SetPosition(0, laser.position);
            line.SetPosition(1, hit.point);
            if (hit.transform.gameObject.tag == "Player")
            {
                hit.transform.gameObject.GetComponent<PlayerMovement>().TakeDamage(dano);

            }

        }
        else
        {
            line.SetPosition(0, laser.position);
            line.SetPosition(1, laser.transform.right * distance);
        }
    }


}
