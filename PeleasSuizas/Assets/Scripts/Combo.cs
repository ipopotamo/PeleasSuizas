using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public Animator anim;
    public int combo;
   // [SerializeField] public Movimiento moviminto;
    public bool atacando;
    public AudioSource audio_s;
    public AudioClip[] sonido;
    
    void Start()
    {
        //moviminto = GetComponent<Moviminto>();
        anim = GetComponent<Animator>();
        audio_s = GetComponent<AudioSource>();

    }

    public void Combos() {
        if (Input.GetKeyDown(KeyCode.C) && !atacando) {
            atacando = true;
            anim.SetTrigger("" + combo);
            audio_s.clip = sonido[combo];
            audio_s.Play();
        }
    }

    public void EMPEZAR_COMBO() {
        //moviminto.velocidadDeMovimiento = 0;
        atacando = false;
        if (combo < 3) {
            combo++;
        }
    }

    public void Final_Combo() {
        //movimiento.velocidadDeMovimiento = 400;
        atacando = false;
        combo = 0;
    }
    // Update is called once per frame
    void Update()
    {
        Combos();
    }
}
