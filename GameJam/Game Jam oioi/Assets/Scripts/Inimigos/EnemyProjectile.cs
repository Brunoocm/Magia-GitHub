using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public int dano;
    public float speed;
    public Transform player;

    private Vector2 target;

    Rigidbody2D rb;
    private Vector2 moveDirection;

    private float timerDestroy;


    void Start()
    {
        player = GameObject.Find("Guerreiro").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();

        moveDirection = (player.position - transform.position).normalized * speed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    void Update()
    {
        timerDestroy += Time.deltaTime;

        if (timerDestroy > 3)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMovement>().TakeDamage(dano);
            Destroy(gameObject);
        }
    }

}
