using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftPoderes : MonoBehaviour
{
    public GameObject craftUI;

    public bool can;
    private bool ativo = false;
    public static bool minigamePoderesAtivo;

    Collider2D coll;
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (CraftAlquimista.minigameAtivo)
        {
            coll.enabled = false;
        }
        else
        {
            coll.enabled = true;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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
