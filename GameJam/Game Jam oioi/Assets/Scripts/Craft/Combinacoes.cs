using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combinacoes : MonoBehaviour
{
    [Header("Drops")]
    public static int olho ; //precisa de 10
    public static int gosma ; //precisa de 10
    public static int lagrima ; //precisa de 10
    public int valorPago;

    [Header("Essencias")]
    public static int essenciaBestial;
    public static int essenciaDoVazio ;
    public static int essenciaEspectral ;

    public GameObject buttonBestial;
    public GameObject buttonDoVazio;
    public GameObject buttonEspectral;

    void Start()
    {

    }

    void Update()
    {
        if (olho < valorPago || gosma < valorPago)
        {
            buttonBestial.GetComponent<Button>().enabled = false;
            buttonBestial.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonBestial.GetComponent<Button>().enabled = true;
            buttonBestial.GetComponent<Image>().color = Color.white;
        }

        if (olho < valorPago || lagrima < valorPago)
        {
            buttonDoVazio.GetComponent<Button>().enabled = false;
            buttonDoVazio.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonDoVazio.GetComponent<Button>().enabled = true;
            buttonDoVazio.GetComponent<Image>().color = Color.white;
        }

        if (lagrima < valorPago || gosma < valorPago)
        {
            buttonEspectral.GetComponent<Button>().enabled = false;
            buttonEspectral.GetComponent<Image>().color = Color.gray;
        }
        else
        {
            buttonEspectral.GetComponent<Button>().enabled = true;
            buttonEspectral.GetComponent<Image>().color = Color.white;
        }

    }

    public void Olho_Gosma()
    {
        if (olho >= valorPago && gosma >= valorPago)
        {
            olho -= valorPago;
            gosma -= valorPago;
            essenciaBestial++;
            CraftAlquimista.minigameAtivo = true;
        }
    }
    public void Olho_Lagrima()
    {
        if (olho >= valorPago && lagrima >= valorPago)
        {
            olho -= valorPago;
            lagrima -= valorPago;
            essenciaDoVazio++;
            CraftAlquimista.minigameAtivo = true;
        }
    }
    public void Lagrima_Gosma()
    {
        if (lagrima >= valorPago && gosma >= valorPago)
        {
            lagrima -= valorPago;
            gosma -= valorPago;
            essenciaEspectral++;
            CraftAlquimista.minigameAtivo = true;
        }
    }

}
