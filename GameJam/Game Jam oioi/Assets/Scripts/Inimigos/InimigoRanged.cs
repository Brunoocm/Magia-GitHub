using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoRanged : MonoBehaviour
{
    public float speed;
    public float stopingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stopingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stopingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (timeBtwShots <= 0)
        {
            anim.SetTrigger("Ataque");
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    public void Atira()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        timeBtwShots = startTimeBtwShots;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, stopingDistance);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, retreatDistance);
    }
}
