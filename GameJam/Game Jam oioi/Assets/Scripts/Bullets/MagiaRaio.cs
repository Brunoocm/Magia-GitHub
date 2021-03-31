using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaRaio : MonoBehaviour
{
    public int dano;
    public Collider2D collider;
    public float tempoAtiva;
    public Color cor;

    private float timer;
    private float timer2;

    void Start()
    {
        collider.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().color = Color.clear;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tempoAtiva)
        {
            collider.enabled = true;
            gameObject.GetComponent<SpriteRenderer>().color = cor;
            timer2 += Time.deltaTime;
        }

        if (timer2 > 0.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("inimigo"))
        {
            print("RAIO COLIDIU");
            other.gameObject.GetComponent<vidaInimigo>().TakeDamage(dano);
        }
    }

}
