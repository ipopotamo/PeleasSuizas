using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    [SerializeField] private Transform control;
    [SerializeField] private float radioAtaque;
    [SerializeField] private float Dano;


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
    private void Golpe() {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, radioAtaque);

        foreach (Collider2D colisionador in objetos) {
            if (colisionador.CompareTag("Jugador2")) 
            {
                colisionador.transform.GetComponent<VidaPJ2>().TomarDaño(Dano);
            }
        }
    }
    public void Combos() {
        if (Input.GetKeyDown(KeyCode.C) && !atacando) {
            Golpe();
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

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(control.position, radioAtaque);
    }
}
