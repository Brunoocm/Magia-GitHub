using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empurraoRotation : MonoBehaviour
{
    public GameObject player;
    public float duracao;
    public float forca;
    public bool timerAtivo;

    private bool ativo;
    private float timer;
    private Vector2 posCamera;
    private Vector2 posPlayer;
    private Vector2 direction;
    private Quaternion rotationBala;
    private Quaternion rotacaoProvisoria;

    Animator anim;

    void Start()
    {
        ativo = false;
        timerAtivo = false;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        posCamera = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        posPlayer = new Vector2(transform.position.x, transform.position.y);
        direction = posCamera - posPlayer;
        rotationBala = Quaternion.Euler(0, 0, Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg);

        this.transform.rotation = rotationBala;

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            rotacaoProvisoria = rotationBala;
            anim.SetTrigger("Empurrar");
        }


        if (timerAtivo)
        {
            timer += Time.deltaTime;
        }
        else timer = 0;

        if (timerAtivo && timer < duracao)
        {
            ativo = true;
        }
        else if (timer > duracao)
        {
            timerAtivo = false;
        }
        else ativo = false;

        if (ativo)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<Collider2D>().enabled = true;
            this.transform.rotation = rotacaoProvisoria;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }

        // GetComponent<SpriteRenderer>().enabled = true;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("inimigo"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * forca);
            player.GetComponent<PlayerMovement>().empurrando = false;
        }
    }
}
