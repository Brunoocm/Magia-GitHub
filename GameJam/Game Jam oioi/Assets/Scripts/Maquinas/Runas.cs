using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Runas : MonoBehaviour
{
    public GameObject[] RunasArray;

    public float timer;
  
    public int randomRuna;

    public bool stopAll;
    public bool can;
    private float resetTimer;

    public float maxHealth;
    public float health;

    public Text text;
    void Start()
    {
        randomRuna = Random.Range(0, 6);
        resetTimer = timer;
    }

    void Update()
    {
        if (CraftPoderes.minigamePoderesAtivo)
        {
            timer -= Time.deltaTime;
            health -= Time.deltaTime;

            text.text = ((int)health).ToString() + "%";

            if (timer <= 0)                
            {                    
                if (!can)                   
                {                     
                    RunasArray[randomRuna].GetComponent<CircleCollider2D>().enabled = true;                       
                    RunasArray[randomRuna].GetComponent<SpriteRenderer>().color = Color.red;                       
                    StartCoroutine(Active());                      
                    can = true;                  
                }                
            }               
            if (health >= maxHealth)               
            {
                    CraftPoderes.minigamePoderesAtivo = false;
                    health = 50;                
            }          
        }
        else
        {
            text.text = " ";
        }
    }

    IEnumerator Active()
    {

        yield return new WaitForSeconds(3);
        for (int i = 0; i < RunasArray.Length; i++)
        {
            RunasArray[i].GetComponent<CircleCollider2D>().enabled = false;
            RunasArray[i].GetComponent<SpriteRenderer>().color = Color.white;
        }
        can = false;
        randomRuna = Random.Range(0, 6);
        timer = resetTimer;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AtkBasico"))
        {
            health += 10;
        }

    }
}
