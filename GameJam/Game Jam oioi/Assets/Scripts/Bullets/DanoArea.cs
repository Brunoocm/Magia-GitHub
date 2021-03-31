using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoArea : MonoBehaviour
{
    public float Speed;
    public int dano;
    public Collider2D colliderArea;

    private bool danoArea;
    Rigidbody2D rid;

    Animator anim;
    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        rid.velocity = transform.right * Speed;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (danoArea) colliderArea.enabled = true;
        else colliderArea.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            rid.velocity = Vector2.zero;
            danoArea = true;
            StartCoroutine(DestroirBala());
            other.gameObject.GetComponent<vidaInimigo>().TakeDamage(dano);
            anim.SetTrigger("Explodir");
        }

    }
    IEnumerator DestroirBala()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
