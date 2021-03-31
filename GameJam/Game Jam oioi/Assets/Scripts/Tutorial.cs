using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject caixaDeTexto;
    public Text text;
    public int numText;
    public int numTextFerreiro;
    public int numTextAlquimista;

    [TextArea(5, 20)]
    public string[] tutoriais;
    [TextArea(5, 20)]
    public string[] tutoriaisFerreiro;
    [TextArea(5, 20)]
    public string[] tutoriaisAlquimista;

    void Start()
    {
        
    }

    void Update()
    {
        if(gameManager.magoAtivo == "guerreiro")
        {
            if (numText < 2)
            {
                text.text = tutoriais[numText];
                caixaDeTexto.SetActive(true);
            }
            else
            {
                caixaDeTexto.SetActive(false);
            }
        }
        if (gameManager.magoAtivo == "ferreiro")
        {           
            if (numTextFerreiro < 2)
            {
                text.text = tutoriaisFerreiro[numTextFerreiro];
                caixaDeTexto.SetActive(true);
            }
            else
            {
                caixaDeTexto.SetActive(false);
            }
        }
        if (gameManager.magoAtivo == "alquimista")
        {           
            if (numTextAlquimista < 2)
            {
                text.text = tutoriaisAlquimista[numTextAlquimista];
                caixaDeTexto.SetActive(true);
            }
            else
            {
                caixaDeTexto.SetActive(false);
            }   
        }
    }

    public void Next()
    {
        if (gameManager.magoAtivo == "guerreiro")
        {
            numText++;
            if(numText == 2)
            {
                caixaDeTexto.SetActive(false);
            }
        }
        if (gameManager.magoAtivo == "ferreiro")
        {
            numTextFerreiro++;
            if (numTextFerreiro == 2)
            {
                caixaDeTexto.SetActive(false);
            }
        }
        if (gameManager.magoAtivo == "alquimista")
        {
            numTextAlquimista++;
            if (numTextAlquimista == 2)
            {
                caixaDeTexto.SetActive(false);
            }
        }
    }
}
