using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaTiming : MonoBehaviour
{
    public BoxCollider2D[] Alvos;

    public float maxHealth;
    public float health;
    public float timerValue;

    private bool stopAll;
    private float timer;
    private int randomAlvo;
    private int lastAlvo;
    void Start()
    {
        RandomNum(1, 4);
    }

    void Update()
    {
        if (!stopAll)
        {
            timer += Time.deltaTime;
            health -= Time.deltaTime;

            if (randomAlvo == 1 && timer >= timerValue)//Alvo Aleatorio
            {
                Alvo1();
            }
            if (randomAlvo == 2 && timer >= timerValue)//Alvo Aleatorio
            {
                Alvo2();
            }
            if (randomAlvo == 3 && timer >= timerValue)//Alvo Aleatorio
            {
                Alvo3();
            }

            if (health >= maxHealth)
            {
                stopAll = true;
                Alvos[0].enabled = false;
                Alvos[1].enabled = false;
                Alvos[2].enabled = false;
            }
        }
    }

    public int RandomNum(int min, int max)
    {
        randomAlvo = Random.Range(min, max);
        while (lastAlvo == randomAlvo)
        {
            randomAlvo = Random.Range(min, max);
        }
        lastAlvo = randomAlvo;
        return randomAlvo;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("AtkBasico"))
        {
            health += 2;
        }
            
    }

    public void Alvo1()
    {
        Alvos[0].enabled = true;
        Alvos[1].enabled = false;
        Alvos[2].enabled = false;
        RandomNum(1, 4);
        timer = 0;
    }
    public void Alvo2()
    {
        Alvos[1].enabled = true;
        Alvos[0].enabled = false;
        Alvos[2].enabled = false;
        RandomNum(1, 4);
        timer = 0;
    }
    public void Alvo3()
    {
        Alvos[2].enabled = true;
        Alvos[0].enabled = false;
        Alvos[1].enabled = false;
        RandomNum(1, 4);
        timer = 0;
    }
}
