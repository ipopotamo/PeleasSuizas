using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboPJ2 : MonoBehaviour
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

    public void Combos2() {
        if (Input.GetKeyDown(KeyCode.I) && !atacando) {
            atacando = true;
            anim.SetTrigger("" + combo);
            audio_s.clip = sonido[combo];
            audio_s.Play();
        }
    }

    public void EMPEZAR_COMBO2() {
        //moviminto.velocidadDeMovimiento = 0;
        atacando = false;
        if (combo < 3) {
            combo++;
        }
    }

    public void Final_Combo2() {
        //movimiento.velocidadDeMovimiento = 400;
        atacando = false;
        combo = 0;
    }
    // Update is called once per frame
    void Update()
    {
        Combos2();
    }
}
