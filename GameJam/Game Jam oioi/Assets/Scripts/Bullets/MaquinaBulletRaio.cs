using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaBulletRaio : MonoBehaviour
{
    public float Speed;


    public Transform pos;

    Rigidbody2D rid;
    Vector2 target;
    void Start()
    {
        target = new Vector2(pos.position.x, pos.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
        StartCoroutine(DestroyObjetc());
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TOMAR DANO
        }

    }

    IEnumerator DestroyObjetc()
    {
        yield return new WaitForSeconds(5);
        Destroy(transform.parent.gameObject);
    }
}
