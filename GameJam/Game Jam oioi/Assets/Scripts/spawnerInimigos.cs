using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnerInimigos : MonoBehaviour
{
    public bool inicio;
    public bool ativo;
    public bool podeAtivar;
    public GameObject fantasma;
    public GameObject slime;
    public GameObject horda;
    public Transform spawnpointFantasma;
    public Transform spawnpointSlime;
    public float timerEntreSpawn;
    public int maxInimigos;
    public int minInimigos;
    public int quantDessaHorda;

    private float timerDuraçãoPausa;
    private float timerSpawn;
    private int inimigosSpawnados;
    private int tempoEntreAtivacao = 15;
    private float proximoSpawn;
    private Collider2D collider;

    void Start()
    {
        quantDessaHorda = Random.Range(minInimigos, maxInimigos);
        collider = GetComponent<Collider2D>();
        podeAtivar = true;
    }

    void Update()
    {
        if (timerDuraçãoPausa >= tempoEntreAtivacao && inimigosSpawnados == 0 || inicio)
        {
            podeAtivar = true;
        }


        if (ativo)
        {
            inicio = false;
            timerSpawn += Time.deltaTime;
            collider.enabled = false;
            timerDuraçãoPausa = 0;
            podeAtivar = false;

            if (timerSpawn >= proximoSpawn)
            {
                if (Random.Range(0, 100) > 50)
                {
                    horda.SetActive(false);
                    Instantiate(fantasma, spawnpointFantasma.position, Quaternion.identity);
                }
                else Instantiate(slime, spawnpointSlime.position, Quaternion.identity);

                timerSpawn = 0;
                inimigosSpawnados++;
                proximoSpawn = Random.Range(timerEntreSpawn - Random.Range(0, 3), timerEntreSpawn + Random.Range(0, 3));
            }

            if (inimigosSpawnados > quantDessaHorda)
            {
                quantDessaHorda = Random.Range(minInimigos, maxInimigos);
                ativo = false;
            }
        }
        else
        {
            if (!inicio)
                timerDuraçãoPausa += Time.deltaTime;
            collider.enabled = true;
            inimigosSpawnados = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (podeAtivar)
            {
                horda.SetActive(true);
                ativo = true;
            }
        }
    }
}
