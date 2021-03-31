using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDeFogo : MonoBehaviour
{

    public float checkRadius;
    public float timer;
    public float dano;

    public Transform Pos;

    private float resetTimer;
    private bool explode;

    SpriteRenderer sprite;
    void Start()
    {
        resetTimer = timer;
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        timer -= Time.deltaTime; 
        Explode();

        if (timer <= 0)
        {
            explode = true;
        }
    }

    void Explode()
    {
        if (explode)
        {
            if (Physics2D.OverlapCircle(Pos.position, checkRadius))
            {
                RaycastHit2D hit = Physics2D.Raycast(Pos.position, transform.right);
                if (hit.transform.gameObject.tag == "Player")
                {
                    //TOMAR DANO
                    hit.transform.gameObject.GetComponent<PlayerMovement>().TakeDamage(dano);
                    print("oi");
                }

            }
            StartCoroutine(DestroyObject());
            sprite.color = Color.red;  
        }
        else
        {

        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}

