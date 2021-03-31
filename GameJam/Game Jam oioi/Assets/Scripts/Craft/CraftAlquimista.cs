using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftAlquimista : MonoBehaviour
{
    public GameObject craftUI;

    private bool ativo = false;
    public static bool minigameAtivo;

    Collider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if(CraftPoderes.minigamePoderesAtivo)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
       
        //Gosma + Olho = Essencia Bestial
        //Lagrima de Fantasma + Olho = Essencia do Vazio
        //Lagrima + Gosma = Essencia Espectral

        //Essencia Espectral + Essencia Bestial = empurrão
        //Essencia vazio + Essencia Espectral = veneno
        //Essencia do Vazio + Essencia Bestial = raio
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            craftUI.SetActive(true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            craftUI.SetActive(false);
        }

    }
}
