using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboPJ2 : MonoBehaviour
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

    private void Golpe()
    {
        if (!Input.GetKeyDown(KeyCode.P)) 
        {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(control.position, radioAtaque);

            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Jugador1"))
                {
                    colisionador.transform.GetComponent<VidaPJ1>().TomarDaño1(Dano);
                }
            }
        }
 
    }

    void Start()
    {
        //moviminto = GetComponent<Moviminto>();
        anim = GetComponent<Animator>();
        audio_s = GetComponent<AudioSource>();

    }

    public void Combos2() {
        if (Input.GetKeyDown(KeyCode.I) && !atacando ) {
            Golpe();
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(control.position, radioAtaque);
    }
}
