using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform guerreiro;
    public Transform ferreiro;
    public Transform alquimista;
    public float Smoof = 0.3f;
    public Vector3 offset;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    [HideInInspector] public string magoAtivo;

    private Transform target;
    private Vector3 vel = Vector3.zero;
    private Vector3 targetPos;

    void Start()
    {
        magoAtivo = "guerreiro";
    }

    void Update()
    {
        if (magoAtivo == "guerreiro")
        {
            target = guerreiro;
        }
        if (magoAtivo == "ferreiro")
        {
            target = ferreiro;
        }
        if (magoAtivo == "alquimista")
        {
            target = alquimista;
        }


        targetPos = target.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref vel, Smoof);

        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
           -10);
        }
    }
}
