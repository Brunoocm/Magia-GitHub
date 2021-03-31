using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioFont;

    public AudioClip RunaAcabada;
    public AudioClip LaserAcabado;
    public AudioClip SpawnFantasma;
    public AudioClip RaioPoder;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void RunaAcabadaSound()
    {
        audioFont.PlayOneShot(RunaAcabada, 0.1f);
    }
    public void LaserAcabadoSound()
    {
        audioFont.PlayOneShot(LaserAcabado, 0.1f);
    }
    public void RaioPoderSound()
    {
        audioFont.PlayOneShot(RaioPoder, 0.1f);
    }

}
