using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Game Control")]
    public float vidaAtual = 3;
    public string magoAtivo;
    public spawnerInimigos spawnerScript;
    public bool podeTrocarMago;
    public GameObject textoEmCombate;
    [Header("Guerreiro")]
    public GameObject guerreiro;
    public GameObject guerreiroFake;
    public Color guerreiroCor;
    public Sprite guerreiroSprite;
    public GameObject barraGuerreiro;
    public Slider sliderGuerreiro;
    [Header("Ferreiro")]
    public GameObject ferreiro;
    public GameObject ferreiroFake;
    public Color ferreiroCor;
    public Sprite ferreiroSprite;
    public GameObject barraFerreiro;
    public Slider sliderFerreiro;
    [Header("Alquimista")]
    public GameObject alquimista;
    public GameObject alquimistaFake;
    public Color alquimistaCor;
    public Sprite alquimistaSprite;
    public GameObject barraAlquimista;
    public Slider sliderAlquimista;
    [Header("Outros")]
    public Image imagemVida;
    public CameraController cameraScript;
    public GameObject roletaPersonagens;
    public GameObject JogarDeNovo;
    public Slider sliderVida;
    public Image sliderBackground;

    [HideInInspector] public static GameManager instance;
    [HideInInspector] public string botaoString;
    [HideInInspector] public bool botaoSelecionado;
    [HideInInspector] public float vidaMax;

    private float sliderValue;
    private bool spawnerAtivo;
    private bool ferreiroAtivo;
    private bool alquimistaAtivo;

    void Start()
    {
        magoAtivo = "guerreiro";
        roletaPersonagens.SetActive(false);
        vidaMax = guerreiro.GetComponent<PlayerMovement>().maxVida;
        vidaAtual = guerreiro.GetComponent<PlayerMovement>().vida;
    }

    void Update()
    {
        spawnerAtivo = spawnerScript.ativo;
        ferreiroAtivo = CraftAlquimista.minigameAtivo;
        alquimistaAtivo = CraftPoderes.minigamePoderesAtivo;

        if (vidaAtual <= 0)
        {
            JogarDeNovo.SetActive(true);
        }

        if (spawnerAtivo || ferreiroAtivo || alquimistaAtivo)
        {
            podeTrocarMago = false;
        }
        else if (!spawnerAtivo && !ferreiroAtivo && !alquimistaAtivo)
        {
            podeTrocarMago = true;
        }

        if (Input.GetKeyDown(KeyCode.Tab) && podeTrocarMago)
        {
            roletaPersonagens.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !podeTrocarMago)
        {
            textoEmCombate.SetActive(true);
            StartCoroutine(desativaTexto());
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            roletaPersonagens.SetActive(false);
            if (botaoSelecionado)
            {
                magoAtivo = botaoString;
            }
        }

        if (magoAtivo == "guerreiro")
        {
            guerreiro.SetActive(true);
            ferreiro.SetActive(false);
            alquimista.SetActive(false);

            guerreiroFake.SetActive(false);
            ferreiroFake.SetActive(true);
            alquimistaFake.SetActive(true);

            cameraScript.magoAtivo = "guerreiro";
            vidaAtual = guerreiro.GetComponent<PlayerMovement>().vida;
            barraAlquimista.SetActive(false);
            barraFerreiro.SetActive(false);
            barraGuerreiro.SetActive(true);
        }
        if (magoAtivo == "ferreiro")
        {
            guerreiro.SetActive(false);
            ferreiro.SetActive(true);
            alquimista.SetActive(false);

            guerreiroFake.SetActive(true);
            ferreiroFake.SetActive(false);
            alquimistaFake.SetActive(true);

            cameraScript.magoAtivo = "ferreiro";
            vidaAtual = ferreiro.GetComponent<PlayerMovement>().vida;
            barraAlquimista.SetActive(false);
            barraFerreiro.SetActive(true);
            barraGuerreiro.SetActive(false);
        }
        if (magoAtivo == "alquimista")
        {
            guerreiro.SetActive(false);
            ferreiro.SetActive(false);
            alquimista.SetActive(true);

            guerreiroFake.SetActive(true);
            ferreiroFake.SetActive(true);
            alquimistaFake.SetActive(false);

            cameraScript.magoAtivo = "alquimista";
            vidaAtual = alquimista.GetComponent<PlayerMovement>().vida;
            barraAlquimista.SetActive(true);
            barraFerreiro.SetActive(false);
            barraGuerreiro.SetActive(false);
        }

        sliderValue = vidaAtual / vidaMax;
        sliderGuerreiro.value = sliderValue;
        sliderAlquimista.value = sliderValue;
        sliderFerreiro.value = sliderValue;
    }

    public void AtivaMago(string _magoAtivo)
    {
        magoAtivo = _magoAtivo;
    }

    IEnumerator desativaTexto()
    {
        yield return new WaitForSeconds(2);
        textoEmCombate.SetActive(false);
    }

}
