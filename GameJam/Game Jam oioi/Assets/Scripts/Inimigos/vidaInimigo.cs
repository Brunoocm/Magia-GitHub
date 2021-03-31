using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaInimigo : MonoBehaviour
{
    public int vida;
    public GameObject itemEspecifico;
    public GameObject itemComum;
    public int quantItems;
    [Range(0, 1)]
    public float chanceItemEspecifico;

    public float num;
    public int quant;

    void Start()
    {
        quant = (int)Random.Range(1, quantItems);
    }

    public void TakeDamage(int valor)
    {
        vida -= valor;
        print(valor);
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(color());
        if (vida <= 0)
        {
            for (int i = 0; i < quant; i++)
            {
                num = Random.Range(0, 100);
                if (num <= chanceItemEspecifico * 100)
                {
                    Instantiate(itemEspecifico, transform.position, Quaternion.identity);                  
                }
                else Instantiate(itemComum, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }


    IEnumerator color()
    {
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
