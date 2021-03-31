using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class combinacoesPoderes : MonoBehaviour
{
    [Header("Poderes")]
    public static bool Empurrao = true;
    public static bool Veneno = true;
    public static bool Raio = true;

    public GameObject buttonEmpurrao;
    public GameObject buttonVeneno;
    public GameObject buttonRaio;
    void Start()
    {
        
    }

    void Update()
    {
        if (Combinacoes.essenciaEspectral < 1 || Combinacoes.essenciaBestial < 1)
        {
            buttonEmpurrao.GetComponent<Button>().enabled = false;
            buttonEmpurrao.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonEmpurrao.GetComponent<Button>().enabled = true;
            buttonEmpurrao.GetComponent<Image>().color = Color.white;
        }

        if (Combinacoes.essenciaEspectral < 1 || Combinacoes.essenciaDoVazio < 1)
        {
            buttonVeneno.GetComponent<Button>().enabled = false;
            buttonVeneno.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonVeneno.GetComponent<Button>().enabled = true;
            buttonVeneno.GetComponent<Image>().color = Color.white;
        }

        if (Combinacoes.essenciaDoVazio < 1 || Combinacoes.essenciaBestial < 1)
        {
            buttonRaio.GetComponent<Button>().enabled = false;
            buttonRaio.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonRaio.GetComponent<Button>().enabled = true;
            buttonRaio.GetComponent<Image>().color = Color.white;
        }
    }

    public void Espectral_Bestial()
    {
        if (Combinacoes.essenciaEspectral >= 1 && Combinacoes.essenciaBestial >= 1)
        {
            Combinacoes.essenciaEspectral--;
            Combinacoes.essenciaBestial--;
            Empurrao = true;
            CraftPoderes.minigamePoderesAtivo = true;
            //EMPURRAO
        }
    }
    public void Espectral_Vazio()
    {
        if (Combinacoes.essenciaEspectral >= 1 && Combinacoes.essenciaDoVazio >= 1)
        {
            Combinacoes.essenciaEspectral--;
            Combinacoes.essenciaDoVazio--;
            Veneno = true;
            CraftPoderes.minigamePoderesAtivo = true;
            //VENENO
        }
    }
    public void Vazio_Bestial()
    {
        if (Combinacoes.essenciaDoVazio >= 1 && Combinacoes.essenciaBestial >= 1)
        {
            Combinacoes.essenciaDoVazio--;
            Combinacoes.essenciaBestial--;
            Raio = true;
            CraftPoderes.minigamePoderesAtivo = true;
            //RAIO
        }
    }
}
