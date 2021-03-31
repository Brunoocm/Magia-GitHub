using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaRaio : MonoBehaviour
{
    public GameObject BulletRaio;
    public GameObject BulletRaioSegunda;
    public Transform BulletPosition;

    public bool primeiro = true;
    public bool segundo;

    public float maxHealth;
    public float health;

    public float Speed;
    public float rota;
    public float timer;

    private float resetTimer;
    private int RandomNum;
    private bool stopAll;

    Vector2 pos;
    void Start()
    {
        resetTimer = timer;
        RandomNum = Random.Range(0, 2);
    }

    void Update()
    {       
        if (!stopAll)
        {
            timer -= Time.deltaTime;
            health -= Time.deltaTime;

            if (timer < 0 && RandomNum == 0)
            {
                Shoot();
            }
            if (timer < 0 && RandomNum == 1)
            {
                Shoot2();
            }

            if (health >= maxHealth)
            {
                stopAll = true;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AtkBasico"))
        {
            health += 2;
        }

    }

    public void Shoot()
    {
        Instantiate(BulletRaio, transform.position, Quaternion.identity);
        timer = resetTimer;
        primeiro = false;
        segundo = true;
        RandomNum = Random.Range(0, 2);
    }
    public void Shoot2()
    {
        Instantiate(BulletRaioSegunda, transform.position, Quaternion.identity);
        timer = resetTimer;
        primeiro = true;
        segundo = false;
        RandomNum = Random.Range(0, 2);
    }
}
