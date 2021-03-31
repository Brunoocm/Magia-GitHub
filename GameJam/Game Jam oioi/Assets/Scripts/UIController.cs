using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Serializable]
    public class Essencia
    {
        public Image imagemUI;
        public Sprite imagemEssencia;
        public Text essenciaText;
        public int essenciaTotal;
    }

    [Serializable]
    public class Item
    {
        public Image imagemUI;
        public Sprite imagemItem;
        public Text itemText;
        public int itemTotal;
    }

    public GameObject barraVida;
    public GameObject inventario;
    public Essencia[] essencias;
    public Item[] items;

    private bool vidaAtiva;
    private bool inventarioAtivo;

    void Start()
    {
        vidaAtiva = true;
    }

    void Update()
    {
        items[0].itemTotal = Combinacoes.olho;
        items[1].itemTotal = Combinacoes.gosma;
        items[2].itemTotal = Combinacoes.lagrima;

        essencias[0].essenciaTotal = Combinacoes.essenciaBestial;
        essencias[1].essenciaTotal = Combinacoes.essenciaDoVazio;
        essencias[2].essenciaTotal = Combinacoes.essenciaEspectral;

        for (int i = 0; i < essencias.Length; i++)
        {
            essencias[i].essenciaText.text = essencias[i].essenciaTotal.ToString();
        }

        for (int i = 0; i < items.Length; i++)
        {
            items[i].itemText.text = items[i].itemTotal.ToString();
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (vidaAtiva)
            {
                vidaAtiva = false;
                inventarioAtivo = true;
            }
            else
            {
                vidaAtiva = true;
                inventarioAtivo = false;
            }
        }

        if (vidaAtiva) barraVida.SetActive(true);
        else barraVida.SetActive(false);
        if (inventarioAtivo) inventario.SetActive(true);
        else inventario.SetActive(false);
    }

}
