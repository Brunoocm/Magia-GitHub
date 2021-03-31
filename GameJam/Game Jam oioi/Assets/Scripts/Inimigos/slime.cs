using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slime : MonoBehaviour
{
    public int dano;
    public float speed;
    public float intervaloPulos;

    private float timerPulo;
    private Transform player;
    private Rigidbody2D rb;
    private Vector2 moveDirection;

    void Start()
    {
        player = GameObject.Find("Guerreiro").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        moveDirection = (player.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void Update()
    {
        timerPulo += Time.deltaTime;
        if (timerPulo >= intervaloPulos)
        {
            moveDirection = (player.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            timerPulo -= timerPulo;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(dano);
        }
    }
}
