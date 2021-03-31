using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Geral")]
    public float maxVida;
    public float vida = 3;
    public float speed;
    public float cooldownCura;
    public float curaPorSegundo;
    public bool temEmpurrao;
    public bool temVeneno;
    public bool temRaio;
    public GameManager gameManager;
    public Transform PosTiro;
    public Animator anim;

    [Header("Ícones Skills")]
    public Color corzinha;
    public Image basicoIcon;
    public Image areaIcon;
    public Image empurraoIcon;
    public Image raioIcon;

    [Header("Atk Basico")]
    public float delayTiro;
    public GameObject Bullet;

    [Header("Dano em Area")]
    public GameObject danoEmArea;
    public float cooldownArea;
    private bool boolArea;
    private float timerArea;

    [Header("Empurrao")]
    public GameObject empurrao;
    public float cooldownEmpurrao;
    public empurraoRotation scriptEmpurrao;
    private bool boolEmpurrao;
    [HideInInspector] public bool empurrando;
    private float timerEmpurrao;

    [Header("Raio")]
    public GameObject raio;
    public float cooldownRaio;
    private bool boolRaio;
    private float timerRaio;

    private float resetDelay;
    private float horizontal;
    private float vertical;
    private float timer;
    private float timerPorSegundo;
    private bool emCombate;

    private Vector2 posCamera;
    private Vector2 posPlayer;
    private Vector2 direction;
    private Quaternion rotationBala;

    Vector2 mov;
    Rigidbody2D rid;


    void Start()
    {
        rid = GetComponent<Rigidbody2D>();
        resetDelay = delayTiro;
        vida = maxVida;
    }

    void Update()
    {
        posCamera = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        posPlayer = new Vector2(transform.position.x, transform.position.y);
        direction = posCamera - posPlayer;
        rotationBala = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);

        Physics2D.IgnoreLayerCollision(0, 8, true);

        temVeneno = combinacoesPoderes.Veneno;
        temEmpurrao = combinacoesPoderes.Empurrao;
        temRaio = combinacoesPoderes.Raio;

        if (boolArea && temVeneno)
        {
            areaIcon.color = Color.white;
        }
        else areaIcon.color = corzinha;

        if (boolEmpurrao && temEmpurrao)
        {
            empurraoIcon.color = Color.white;
        }
        else empurraoIcon.color = corzinha;

        if (boolRaio && temRaio)
        {
            raioIcon.color = Color.white;
        }
        else raioIcon.color = corzinha;


        //Controle dos cooldowns
        timerArea += Time.deltaTime;
        timerEmpurrao += Time.deltaTime;
        timerRaio += Time.deltaTime;

        if (timerArea >= cooldownArea)
        {
            boolArea = true;
        }
        else boolArea = false;

        if (timerEmpurrao >= cooldownEmpurrao)
        {
            boolEmpurrao = true;
        }
        else
        {
            boolEmpurrao = false;
        }

        if (timerRaio >= cooldownRaio)
        {
            boolRaio = true;
        }
        else boolRaio = false;


        if (boolArea && Input.GetKeyDown(KeyCode.Alpha1) && combinacoesPoderes.Veneno)
        {
            Instantiate(danoEmArea, PosTiro.position, rotationBala);
            timerArea = 0;
        }

        if (boolEmpurrao && Input.GetKeyDown(KeyCode.Alpha2) && combinacoesPoderes.Empurrao)
        {
            empurrando = true;
            timerEmpurrao = 0;
            scriptEmpurrao.timerAtivo = true;
        }

        if (boolRaio && Input.GetKeyDown(KeyCode.Alpha3) && combinacoesPoderes.Raio)
        {
            Instantiate(raio, posCamera, Quaternion.identity);
            timerRaio = 0;
        }

        delayTiro -= Time.deltaTime;
        if (delayTiro < 0)
        {
            Tiro();
        }
        mov.x = Input.GetAxisRaw("Horizontal"); //movement
        mov.y = Input.GetAxisRaw("Vertical"); //movement

        anim.SetFloat("Horizontal", mov.x);
        anim.SetFloat("Vertical", mov.y);
        anim.SetFloat("Speed", mov.sqrMagnitude);

        timer += Time.deltaTime;

        if (timer >= cooldownCura)
        {
            emCombate = false;
        }
        else emCombate = true;

        if (!emCombate && vida < maxVida)
        {
            timerPorSegundo += Time.deltaTime;
            if (timerPorSegundo >= 1)
            {
                vida += curaPorSegundo;
                timerPorSegundo -= timerPorSegundo;
            }
        }
    }

    private void FixedUpdate()
    {
        if (mov.x != 0 && mov.y != 0)
        {
            mov.x *= 0.8f;
            mov.y *= 0.8f;
        }

        rid.velocity = new Vector2(mov.x * speed, mov.y * speed);
    }


    void Tiro()
    {
        if (Input.GetMouseButton(0))
        {
            GameObject AtkBasico = (GameObject)Instantiate(Bullet, PosTiro.position, rotationBala);
            delayTiro = resetDelay;
        }
    }

    public void TakeDamage(float damage)
    {
        vida -= damage;
        timer = 0;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(Feedback());

    }

    IEnumerator Feedback()
    {
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }


}
