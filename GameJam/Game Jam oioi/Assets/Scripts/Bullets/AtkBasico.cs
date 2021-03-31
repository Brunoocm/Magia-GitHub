using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkBasico : MonoBehaviour
{
    public float Speed;
    public int dano;

    Rigidbody2D rid;

    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        rid.velocity = transform.right * Speed;
        StartCoroutine(DestroirBala());
    }

    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
        else if (other.gameObject.CompareTag("inimigo"))
        {
            other.gameObject.GetComponent<vidaInimigo>().TakeDamage(dano);
            Destroy(gameObject);
        }

    }
    IEnumerator DestroirBala()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
