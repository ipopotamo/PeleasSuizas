using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comboPJ2 : MonoBehaviour
{
    [SerializeField] private Transform control;
    [SerializeField] public float radioAtaque;
    [SerializeField] private float Dano;

    private bool puedeTransformarse = false;
    private bool transformado = false;

    public bool TRANSFORMADOO{get => transformado; set => transformado = value;}

    private VidaPJ2 Mivida;

    public Animator anim;
    public int combo;

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
        Mivida = GetComponent<VidaPJ2>();
        //moviminto = GetComponent<Moviminto>();
        anim = GetComponent<Animator>();
        audio_s = GetComponent<AudioSource>();

    }

    public void Combos2() {
        if (Input.GetKeyDown(KeyCode.I) && !atacando && Mivida.vida > 0) {
            Golpe();
            atacando = true;
            anim.SetTrigger("" + combo);
            //audio_s.clip = sonido[combo];
            //audio_s.Play();
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
        Combos2();

        if (Mivida.vida <= 100){
            puedeTransformarse = true;

        }
        
        if(Input.GetKey("u") && puedeTransformarse == true && transformado == false)
            {
                anim.SetTrigger("tranformer");
                transformado = true;
                    if (transformado)
                        {
                            anim.SetTrigger("tranformer");
                            anim.SetLayerWeight(0, 0);
                            anim.SetLayerWeight(1, 1);
                            
                        }
                    //anim.SetTrigger("tranformer");
            }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(control.position, radioAtaque);
    }
}
