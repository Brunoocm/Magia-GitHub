using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fornalha : MonoBehaviour
{
    public float timerSobreviver;
    public float timer;
    public int[] speeds;

    private float sobreviverReset;
    private float resetTimer;
    private int RandomNum;

    [Header("Positions")]
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public GameObject BolinhaFogo;

    public GameObject laser;
    public GameObject laser2;
    public GameObject laser3;

    public Text sobreviva;
    private Text reset;

    void Start()
    {
        RandomNum = Random.Range(0, 3);
        sobreviverReset = timerSobreviver;
        resetTimer = timer;
    }

    void Update()
    {
        if (CraftAlquimista.minigameAtivo)
        {
            timer -= Time.deltaTime;
            timerSobreviver -= Time.deltaTime;
            transform.Rotate(0, 0, speeds[RandomNum] * Time.deltaTime);
            if (timer <= 0)
            {
                RandomNum = Random.Range(0, 3);
                SpawnBola();
                timer = resetTimer;
                laser.GetComponent<LineRenderer>().enabled = true;
                laser2.GetComponent<LineRenderer>().enabled = true;
                laser3.GetComponent<LineRenderer>().enabled = true;
                sobreviva.enabled = true;
            }
        
            if(timerSobreviver <= 0)
            {
                CraftAlquimista.minigameAtivo = false;
                timerSobreviver = sobreviverReset;
                laser.GetComponent<LineRenderer>().enabled = false;
                laser2.GetComponent<LineRenderer>().enabled = false;
                laser3.GetComponent<LineRenderer>().enabled = false;
                sobreviva.enabled = false;

            }

            sobreviva.text =  ((int)timerSobreviver).ToString();
        }
        else
        {
            sobreviva.text = " ";

        }


    }

    void SpawnBola()
    {

        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Instantiate(BolinhaFogo, pos, transform.rotation);

    }
}
